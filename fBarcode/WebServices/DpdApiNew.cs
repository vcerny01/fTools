using System;
using fBarcode.Fichema;
using fBarcode.Logging;
using fBarcode.Exceptions;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using static ServiceReference.DpdNew.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
//using Newtonsoft.Json; MAYBE I CAN USE NEWTONSOFT ???

namespace fBarcode.WebServices
{
	public static class DpdApiNew
	{
		private static JsonSerializerOptions options = new JsonSerializerOptions
		{
			WriteIndented = true,
			PropertyNamingPolicy = new FirstLetterLowerCaseNamingPolicy(),
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
			Converters = { new RoundedNumericConverter()}

		};
		private static string apiEndpointShipments = "https://shipping.dpdgroup.com/api/v1.1/shipments";
		//private static string apiEndpointPickup = "https://shipping.dpdgroup.com/api/v1.1/pickup";

		//https://nst-preprod.dpsin.dpdgroup.com/api/v1.1/pickup 

		public static (byte[], string) GetParcelLabel(DpdParcel parcel)
		{
			string response;
			var parcels = new ExternalShipmentParcelDTO[parcel.IsMultiParcel ? parcel.MultiParcelCount : 1];
			for (int i = 0; i < parcels.Length; i++)
			{
				parcels[i] = new ExternalShipmentParcelDTO()
				{
					Reference1 = parcel.ReferenceNumber + "p" + i,
					Weight = parcel.Weight,
				};
			}
			// if (parcel.IsCashOnDelivery)
			// {
			// 	parcels[0].CodAmount = Convert.ToDouble(parcel.Price);
			// }
			var shipmentRequest = new NewExternalShipmentRequest()
			{
				BuCode = "015", // jedná se o kód - oznaèení jednotlivých zemí DPD, pro CR 015
				CustomerId = AdminSettings.Dpd.CustomerId,
				Shipments = new ExternalShipmentRequestDTO[]
				{
					new ExternalShipmentRequestDTO()
					{
						NumOrder = 1,
						SaveMode = "printed", // LOOK INTO IT
						PrintFormat = "PDF",
						LabelSize = "A6",
						SenderAddressId = AdminSettings.Dpd.SenderAddressId,
						Reference1 = parcel.ReferenceNumber,
						Parcels = parcels,
						Receiver = new ExternalShipmentReceiverAddressDTO()
						{
							City = parcel.recipient.City,
							CompanyName = parcel.recipient.isCompany ? parcel.recipient.CompanyName : null,
							ContactEmail = parcel.recipient.EmailAdress,
							ContactMobile = parcel.recipient.PhoneNumber,
							ContactName = string.Join(" ", parcel.recipient.FirstName, parcel.recipient.LastName),
							CountryCode = parcel.recipient.CountryIso,
							HouseNo = parcel.recipient.HouseNumber,
							Name = string.Join(" ", parcel.recipient.FirstName, parcel.recipient.LastName),
							Street = parcel.recipient.Street,
							ZipCode = parcel.recipient.PostalCode,
						},
						Service = new CreationExternalShipmentServiceDTO()
						{
							MainServiceElementCodes = parcel.isParcelShop ? new string[] { "001", "013", "200"} : new string[] {"001", "013"}, // Codes for DPD Private

							AdditionalService = new ExternalShipmentAdditionalServiceDTO()
							{
								Predicts = new ExternalPredictDTO[]
								{
									new ExternalPredictDTO()
									{
										Destination = parcel.recipient.PhoneNumber,
										Type = "SMS"
									},
									new ExternalPredictDTO()
									{
										Destination = parcel.recipient.EmailAdress,
										Type = "email"
									}
								},
								PudoId = parcel.isParcelShop ? parcel.ParcelShopId : null,
								Cod = parcel.IsCashOnDelivery ? new ExternalCodDTO()
								{
									Currency = "CZK",
									PaymentType = "Cash",
									Amount = Convert.ToDouble(parcel.Price),
									Reference = parcel.VariableSymbol, // Max length of this field is validated based on configuration of [Reference input limit] on BU Configuration screen. Refer to Configure Product Settings for BU.
									Split = "even"
								} : null,

							}
						},
					}
				}
			};
			File.WriteAllText("C:\\Users\\Lisensklad2\\Documents\\TEST\\api_input.txt", JsonSerializer.Serialize(shipmentRequest));
			response = PostData(apiEndpointShipments, JsonSerializer.Serialize(shipmentRequest, options));
			return ParseResponse(response, parcel.OrderNumber);
		}

		private static string PostData(string url, string body)
		{
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AdminSettings.Dpd.ApiToken);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
				HttpResponseMessage response = client.PostAsync(url, content).Result;
				string result = response.Content.ReadAsStringAsync().Result;

				return result;
			}
		}
		private static (byte[], string) ParseResponse(string rawResponse, string orderNumber)
		{
			try
			{
				var jsonDoc = JsonDocument.Parse(rawResponse);
				var shipmentResults = jsonDoc.RootElement.GetProperty("shipmentResults")[0];
				var labelFile = shipmentResults.GetProperty("labelFile").GetString().Split(',')[1];
				var parcelNumber = shipmentResults.GetProperty("parcelResults")[0].GetProperty("parcelNumber").GetString();
				var pdfBytes = Convert.FromBase64String(labelFile);
				return (pdfBytes, parcelNumber);
			}
			catch
			{
				throw new ApiOperationFailedException(orderNumber, rawResponse);
			}
		}
		private class FirstLetterLowerCaseNamingPolicy : JsonNamingPolicy
		{
			public override string ConvertName(string name)
			{
				if (string.IsNullOrEmpty(name) || !char.IsUpper(name[0]))
				{
					return name;
				}

				return char.ToLower(name[0]) + name.Substring(1);
			}
		}
		private class RoundedNumericConverter : JsonConverter<double>
		{
			public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				// Implementation for deserialization is not needed for this example.
				throw new NotImplementedException();
			}

			public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
			{
				value = Math.Round(value, 2); // Round the value to two decimal places
				writer.WriteNumberValue(value);
			}
		}
	}
}