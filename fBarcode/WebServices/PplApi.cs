using fBarcode.Fichema;
using fBarcode.Logging;
using RestSharp;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.VisualBasic;
using ServiceReference.Ppl;
using System.Collections.Generic;
using System.IO;
using System.Net;
using fBarcode.Exceptions;

namespace fBarcode.WebServices
{
	public class PplApi
	{
		private static int clientId = @AdminSettings.Ppl.ClientId;
		private static string clientSecret = @AdminSettings.Ppl.ClientSecret;
		private const string apiLoginUrl = "https://api-dev.dhl.com/ecs/ppl/myapi2/login/getAccessToken";
		private static string bearerToken = GetBearerToken();
		private static bool bearerRefreshed = true;

		public static (byte[], string) GetParcelLabel(PplParcel parcel)
		{
			var rawRequest = Newtonsoft.Json.JsonConvert.SerializeObject(BuildShipmentBatchRequest(parcel));
			var response = PostData(@AdminSettings.Ppl.ApiUrl, rawRequest);

			if (response.StatusCode != HttpStatusCode.Created)
			{
				if (bearerRefreshed) // we already tried once
				{
					throw new ApiOperationFailedException(parcel.OrderNumber,
						"Není možné získat platný Bearer token pro PPL API");
				}

				bearerToken = GetBearerToken();
				bearerRefreshed = true;

				response = PostData(@AdminSettings.Ppl.ApiUrl, rawRequest);

				if (response.StatusCode != HttpStatusCode.Created)
				{
					throw new ApiOperationFailedException(parcel.OrderNumber,
						"Není možné získat platný Bearer token pro PPL API");
				}
			}
			bearerRefreshed = false;
			return ParseResponse(response.Content, parcel.OrderNumber);
		}


		private static Models.ShipmentBatchRequest BuildShipmentBatchRequest(PplParcel parcel)
		{
			var shipments = new List<Models.Shipment>
			{
				new Models.Shipment()
				{
					ReferenceId = parcel.ReferenceNumber,
					ProductType = parcel.IsCashOnDelivery ? "BUSD" : "BUSS",
					Recipient = new Models.Address()
					{
						Name = parcel.recipient.FirstName + " " + parcel.recipient.LastName,
						Street = parcel.recipient.Street + " " + parcel.recipient.HouseNumber,
						City = parcel.recipient.City,
						ZipCode = parcel.recipient.PostalCode,
						Country = parcel.recipient.CountryIso,
						Email = parcel.recipient.EmailAdress,
						Phone = parcel.recipient.PhoneNumber,
					},
					ShipmentSet = new Models.ShipmentSet()
					{
						NumberOfShipments = parcel.IsMultiParcel ? parcel.MultiParcelCount : 1,
						ShipmentSetItems = new List<Models.ShipmentSetItem>()
						{
							new Models.ShipmentSetItem()
							{
								WeighedShipmentInfo = new Models.WeighedShipmentInfo()
								{
									Weight = parcel.Weight
								}
							}
						}
					},
					CashOnDelivery = parcel.IsCashOnDelivery ? new Models.Cod()
					{
						Price = Convert.ToDouble(parcel.Price),
						Currency = parcel.Currency,
						VarSym = parcel.VariableSymbol
					} : null,
					// services might need to be added
				}
			};

			var request = new Models.ShipmentBatchRequest()
			{
				LabelSettings = new Models.LabelSettings()
				{
					Format = "PDF",
					CompleteLabelSettings = new Models.CompleteLabelSettings()
					{
						IsCompleteLabelRequested = true,
						PageSize = "A6",
					}
				},
				Shipments = shipments,
			};
			return request;
		}

		private static IRestResponse PostData(string url, string body)
		{
			var client = new RestClient(@AdminSettings.Ppl.ApiUrl);
			var request = new RestRequest("/shipment/batch", Method.POST);
			request.AddHeader("Authorization", $"Bearer {bearerToken}");
			request.AddHeader("Accept-Language", "");
			request.AddHeader("X-Correlation-ID", "");
			request.AddHeader("X-LogLevel", "");
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", body, ParameterType.RequestBody);
			var response = client.Execute(request);
			File.WriteAllText(@"C:\Users\Lisensklad2\Documents\ppl-response.txt", response.Content.ToString());
			return response;
		}

		private static (byte[], string) ParseResponse(string rawResponse, string orderNumber)
		{
			return (null, null);
		}

		private static string GetBearerToken()
		{
			var client = new RestClient(apiLoginUrl);
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			request.AddParameter("grant_type", "client_credentials");
			request.AddParameter("client_id", @AdminSettings.Ppl.ClientId);
			request.AddParameter("client_secret", @AdminSettings.Ppl.ClientSecret);
			request.AddParameter("scope", "myapi2");
			IRestResponse response = client.Execute(request);
			if (!response.IsSuccessful)
				throw new Exception($"Nepovedlo se získat bearer token k CPL API (PPL): {response.StatusCode} - {response.Content}");
			var json = JObject.Parse(response.Content);
			return json["access_token"]?.ToString();
		}
	}
}