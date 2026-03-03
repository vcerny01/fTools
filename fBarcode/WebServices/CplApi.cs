using fBarcode.Fichema;
using fBarcode.Logging;
using fBarcode.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace fBarcode.WebServices
{
	/// <summary>
	/// PPL/DHL MyAPI2 integration (CPL API).
	/// 
	/// Flow (asynchronous, per the API docs):
	///   1. POST  /shipment/batch          → 201 + Location header with batchId
	///   2. GET   /shipment/batch/{batchId} → poll until importState == "Complete"
	///                                        → returns shipmentNumber + labelUrl
	///   3. GET   /data/{dataGuid}          → returns the PDF label bytes
	/// </summary>
	public static class CplApi
	{
		// ── Constants ──────────────────────────────────────────────────────
		private const string LoginUrl =
			"https://api.dhl.com/ecs/ppl/myapi2/login/getAccessToken";

		private const int MaxPollAttempts = 20;
		private const int PollIntervalMs = 1500;

		// ── Auth state ─────────────────────────────────────────────────────
		private static string _bearerToken = FetchBearerToken();
		private static bool _tokenRefreshed = true;

		// ── Shared HTTP helpers ────────────────────────────────────────────
		private static readonly JsonSerializerSettings JsonSettings = new()
		{
			NullValueHandling = NullValueHandling.Ignore,
		};

		private static HttpClient CreateAuthorizedClient()
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Bearer", _bearerToken);
			client.DefaultRequestHeaders.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}

		// ════════════════════════════════════════════════════════════════════
		//  PUBLIC ENTRY POINT
		// ════════════════════════════════════════════════════════════════════

		/// <summary>
		/// Creates a shipment via the PPL MyAPI2 batch endpoint, polls for
		/// completion, downloads the label, and returns (pdfBytes, shipmentNumber).
		/// </summary>
		public static (byte[], string) GetParcelLabel(PplParcel parcel)
		{
			string baseUrl = AdminSettings.Ppl.ApiUrl.TrimEnd('/');

			// ── Step 1: POST /shipment/batch → get batchId ─────────────
			string body = JsonConvert.SerializeObject(BuildRequest(parcel), JsonSettings);
			string batchId = CreateBatch(baseUrl, body, parcel.OrderNumber);

			// ── Step 2: Poll GET /shipment/batch/{batchId} → status ────
			var (shipmentNumber, labelUrl) = PollBatchStatus(baseUrl, batchId, parcel.OrderNumber);

			// ── Step 3: GET /data/{dataGuid} → download PDF label ──────
			byte[] pdfBytes = DownloadLabel(labelUrl, parcel.OrderNumber);

			return (pdfBytes, shipmentNumber);
		}

		// ════════════════════════════════════════════════════════════════════
		//  STEP 1 – Create shipment batch
		// ════════════════════════════════════════════════════════════════════

		private static string CreateBatch(string baseUrl, string body, string orderNumber)
		{
			string url = baseUrl + "/shipment/batch";
			var (status, _, headers) = PostWithHeaders(url, body);

			// Retry once with a fresh token on auth failure
			if (status == HttpStatusCode.Unauthorized || status == HttpStatusCode.Forbidden)
			{
				if (_tokenRefreshed)
					throw new ApiOperationFailedException(orderNumber,
						$"CPL/PPL API: autorizace selhala ({(int)status})");

				_bearerToken = FetchBearerToken();
				_tokenRefreshed = true;
				(status, _, headers) = PostWithHeaders(url, body);
			}
			_tokenRefreshed = false;

			if (status != HttpStatusCode.Created)
				throw new ApiOperationFailedException(orderNumber,
					$"CPL/PPL API: nepodařilo se vytvořit zásilku ({(int)status} {status})");

			// batchId is in the Location header (UUID format)
			string location = headers?["Location"];
			if (string.IsNullOrEmpty(location))
				throw new ApiOperationFailedException(orderNumber,
					"CPL/PPL API: odpověď neobsahuje Location header s batchId");

			// Location may be a full URL or just the batchId
			string batchId = location.Contains("/")
				? location.Substring(location.LastIndexOf('/') + 1)
				: location;

			return batchId;
		}

		// ════════════════════════════════════════════════════════════════════
		//  STEP 2 – Poll batch status until Complete
		// ════════════════════════════════════════════════════════════════════

		private static (string shipmentNumber, string labelUrl) PollBatchStatus(
			string baseUrl, string batchId, string orderNumber)
		{
			string url = $"{baseUrl}/shipment/batch/{batchId}";

			for (int attempt = 0; attempt < MaxPollAttempts; attempt++)
			{
				Thread.Sleep(PollIntervalMs);

				var (status, responseBody) = Get(url);

				if (status != HttpStatusCode.OK)
					continue; // not ready yet, keep polling

				var json = JObject.Parse(responseBody);
				var items = json["items"] as JArray;
				if (items == null || items.Count == 0)
					continue;

				var firstItem = items[0];
				string importState = firstItem["importState"]?.ToString();

				if (importState == "Complete")
				{
					string shipmentNumber = firstItem["shipmentNumber"]?.ToString();
					string labelUrl = firstItem["labelUrl"]?.ToString()?.Trim();

					if (string.IsNullOrEmpty(shipmentNumber))
						throw new ApiOperationFailedException(orderNumber,
							$"CPL/PPL API: odpověď neobsahuje číslo zásilky – {responseBody}");

					if (string.IsNullOrEmpty(labelUrl))
						throw new ApiOperationFailedException(orderNumber,
							$"CPL/PPL API: odpověď neobsahuje URL štítku – {responseBody}");

					return (shipmentNumber, labelUrl);
				}

				if (importState == "Error" || importState == "Invalid")
				{
					throw new ApiOperationFailedException(orderNumber,
						$"CPL/PPL API: import zásilky selhal ({importState}) – {responseBody}");
				}

				// importState == "InProcess" → keep polling
			}

			throw new ApiOperationFailedException(orderNumber,
				$"CPL/PPL API: zásilka nebyla zpracována v časovém limitu (batch {batchId})");
		}

		// ════════════════════════════════════════════════════════════════════
		//  STEP 3 – Download label PDF
		// ════════════════════════════════════════════════════════════════════

		private static byte[] DownloadLabel(string labelUrl, string orderNumber)
		{
			using var client = CreateAuthorizedClient();
			var response = client.GetAsync(labelUrl).Result;

			if (!response.IsSuccessStatusCode)
				throw new ApiOperationFailedException(orderNumber,
					$"CPL/PPL API: nepodařilo se stáhnout štítek ({(int)response.StatusCode}) z {labelUrl}");

			return response.Content.ReadAsByteArrayAsync().Result;
		}

		// ════════════════════════════════════════════════════════════════════
		//  Request builder
		// ════════════════════════════════════════════════════════════════════

		private static BatchRequest BuildRequest(PplParcel parcel)
		{
			int pieceCount = parcel.IsMultiParcel ? parcel.MultiParcelCount : 1;

			var items = new List<ShipmentSetItem>();
			for (int i = 0; i < pieceCount; i++)
				items.Add(new ShipmentSetItem
				{
					WeighedShipmentInfo = new WeighedShipmentInfo { Weight = parcel.Weight }
				});

			string refId = !string.IsNullOrEmpty(parcel.ReferenceNumber)
				? parcel.ReferenceNumber
				: parcel.OrderNumber;

			var shipment = new Shipment
			{
				ReferenceId = refId,
				ProductType = parcel.IsCashOnDelivery ? "BUSD" : "BUSS",
				Recipient = new Address
				{
					Name    = $"{parcel.recipient.FirstName} {parcel.recipient.LastName}",
					Name2   = parcel.recipient.isCompany ? parcel.recipient.CompanyName : null,
					Street  = $"{parcel.recipient.Street} {parcel.recipient.HouseNumber}",
					City    = parcel.recipient.City,
					ZipCode = parcel.recipient.PostalCode,
					Country = parcel.recipient.CountryIso,
					Phone   = parcel.recipient.PhoneNumber,
					Email   = parcel.recipient.EmailAdress,
				},
				ShipmentSet = new ShipmentSet
				{
					NumberOfShipments = pieceCount,
					ShipmentSetItems  = items,
				},
				CashOnDelivery = parcel.IsCashOnDelivery
					? new CodInfo
					{
						CodCurrency = parcel.Currency,
						CodPrice    = Convert.ToDouble(parcel.Price),
						CodVarSym   = parcel.VariableSymbol,
					}
					: null,
				// Parcel shop delivery: set the AccessPointCode
				SpecificDelivery = parcel.isParcelShop && !string.IsNullOrEmpty(parcel.ParcelShopCode)
					? new SpecificDelivery { ParcelShopCode = parcel.ParcelShopCode }
					: null,
			};

			return new BatchRequest
			{
				LabelSettings = new LabelSettings
				{
					Format = "PDF",
					CompleteLabelSettings = new CompleteLabelSettings
					{
						IsCompleteLabelRequested = true,
						PageSize = "A6",
					}
				},
				Shipments = new List<Shipment> { shipment },
			};
		}

		// ════════════════════════════════════════════════════════════════════
		//  Low-level HTTP
		// ════════════════════════════════════════════════════════════════════

		private static (HttpStatusCode status, string body, WebHeaderCollection headers)
			PostWithHeaders(string url, string json)
		{
			using var client = CreateAuthorizedClient();
			var content  = new StringContent(json, Encoding.UTF8, "application/json");
			var response = client.PostAsync(url, content).Result;
			string body  = response.Content.ReadAsStringAsync().Result;

			// Collect relevant response headers
			var headers = new WebHeaderCollection();
			if (response.Headers.Location != null)
				headers["Location"] = response.Headers.Location.ToString();

			return (response.StatusCode, body, headers);
		}

		private static (HttpStatusCode status, string body) Get(string url)
		{
			using var client = CreateAuthorizedClient();
			var response = client.GetAsync(url).Result;
			string body  = response.Content.ReadAsStringAsync().Result;
			return (response.StatusCode, body);
		}

		// ════════════════════════════════════════════════════════════════════
		//  OAuth2 client-credentials
		// ════════════════════════════════════════════════════════════════════

		private static string FetchBearerToken()
		{
			using var client = new HttpClient();
			var form = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("grant_type",    "client_credentials"),
				new KeyValuePair<string, string>("client_id",     AdminSettings.Ppl.ClientId.ToString()),
				new KeyValuePair<string, string>("client_secret", AdminSettings.Ppl.ClientSecret),
				new KeyValuePair<string, string>("scope",         "myapi2"),
			});

			var response = client.PostAsync(LoginUrl, form).Result;
			string body  = response.Content.ReadAsStringAsync().Result;

			if (!response.IsSuccessStatusCode)
				throw new Exception(
					$"CPL/PPL API: nelze získat bearer token – {response.StatusCode} – {body}");

			return JObject.Parse(body)["access_token"]?.ToString()
				?? throw new Exception("CPL/PPL API: access_token v odpovědi chybí");
		}

		// ════════════════════════════════════════════════════════════════════
		//  DTOs — PPL MyAPI2 /shipment/batch
		// ════════════════════════════════════════════════════════════════════
		#region DTOs

		private class BatchRequest
		{
			[JsonProperty("labelSettings")]
			public LabelSettings LabelSettings { get; set; }

			[JsonProperty("shipments")]
			public List<Shipment> Shipments { get; set; }
		}

		private class LabelSettings
		{
			[JsonProperty("format")]
			public string Format { get; set; }

			[JsonProperty("completeLabelSettings")]
			public CompleteLabelSettings CompleteLabelSettings { get; set; }
		}

		private class CompleteLabelSettings
		{
			[JsonProperty("isCompleteLabelRequested")]
			public bool IsCompleteLabelRequested { get; set; }

			[JsonProperty("pageSize")]
			public string PageSize { get; set; }
		}

		private class Shipment
		{
			[JsonProperty("referenceId")]
			public string ReferenceId { get; set; }

			[JsonProperty("productType")]
			public string ProductType { get; set; }

			[JsonProperty("recipient")]
			public Address Recipient { get; set; }

			[JsonProperty("shipmentSet")]
			public ShipmentSet ShipmentSet { get; set; }

			[JsonProperty("cashOnDelivery")]
			public CodInfo CashOnDelivery { get; set; }

			[JsonProperty("specificDelivery")]
			public SpecificDelivery SpecificDelivery { get; set; }
		}

		private class Address
		{
			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("name2")]
			public string Name2 { get; set; }

			[JsonProperty("street")]
			public string Street { get; set; }

			[JsonProperty("city")]
			public string City { get; set; }

			[JsonProperty("zipCode")]
			public string ZipCode { get; set; }

			[JsonProperty("country")]
			public string Country { get; set; }

			[JsonProperty("phone")]
			public string Phone { get; set; }

			[JsonProperty("email")]
			public string Email { get; set; }
		}

		private class ShipmentSet
		{
			[JsonProperty("numberOfShipments")]
			public int NumberOfShipments { get; set; }

			[JsonProperty("shipmentSetItems")]
			public List<ShipmentSetItem> ShipmentSetItems { get; set; }
		}

		private class ShipmentSetItem
		{
			[JsonProperty("weighedShipmentInfo")]
			public WeighedShipmentInfo WeighedShipmentInfo { get; set; }
		}

		private class WeighedShipmentInfo
		{
			[JsonProperty("weight")]
			public double Weight { get; set; }
		}

		private class CodInfo
		{
			[JsonProperty("codCurrency")]
			public string CodCurrency { get; set; }

			[JsonProperty("codPrice")]
			public double CodPrice { get; set; }

			[JsonProperty("codVarSym")]
			public string CodVarSym { get; set; }
		}

		private class SpecificDelivery
		{
			[JsonProperty("parcelShopCode")]
			public string ParcelShopCode { get; set; }
		}

		#endregion
	}
}