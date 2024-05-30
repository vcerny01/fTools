using System;
using fBarcode.Fichema;
using fBarcode.Exceptions;
using DpdReference;
using fBarcode.Logging;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using static ServiceReference.DpdNew.Models;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.Windows.Forms;
//using Newtonsoft.Json; MAYBE I CAN USE NEWTONSOFT ???

namespace fBarcode.WebServices
{
	public static class DpdApiNew
	{
		private static string accessToken = "";
		private static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
		private static string customerId = "";
		private static int addressId = 0;
		private static string apiEndpoint = "";

		//https://nst-preprod.dpsin.dpdgroup.com/api/v1.1/pickup 

		public static (byte[], string) GetParcelLabel(DpdParcel parcel)
		{
			string rawJson;
			if (parcel.isParcelShop)
			{
				var pickup = new ExternalPickupOrderRequestDTO()
				{
					CustomerId = customerId,
					PickupOrder = new ExternalPickupOrderDTO()
					{
						ContactEmail = parcel.recipient.EmailAdress,
						ContactName = string.Join(" ", parcel.recipient.FirstName, parcel.recipient.LastName),
						ContactPhone = long.Parse(parcel.recipient.PhoneNumber.Replace(" ", "")),
						ParcelCount = parcel.IsMultiParcel ? parcel.MultiParcelCount : 1,
						PickupDate = DateTime.Now.ToString("yyyyMMdd"),
						TotalWeight = parcel.IsMultiParcel ? parcel.MultiParcelCount * parcel.Weight : parcel.Weight,
						InternalPickupAddressId = long.Parse(parcel.ParcelShopId.Replace(" ", "")) // May need to change to ShipmentId or externalPickupId
					}
				};
				rawJson = JsonSerializer.Serialize(pickup, options);
			}
			else
			{


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
					CustomerId = customerId,
					Shipments = new ExternalShipmentRequestDTO[]
					{
					new ExternalShipmentRequestDTO()
					{
						NumOrder = 1,
						SaveMode = "printed", // LOOK INTO IT
						PrintFormat = "PDF",
						LabelSize = "A6",
						SenderAddressId = addressId,
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
							MainServiceCode = parcel.MainServiceCode.ToString(), // Myslim, ze je nastaveno 109, ale kdyztak nsastav 101
							AdditionalService = new ExternalShipmentAdditionalServiceDTO()
							{
								Cod = parcel.IsCashOnDelivery ? new ExternalCodDTO()
								{
									Currency = "CZK",
									PaymentType = "Cash",
									Amount = Convert.ToDouble(parcel.Price),
									Reference = parcel.VariableSymbol, // TO DO: Max length of this field is validated based on configuration of [Reference input limit] on BU Configuration screen. Refer to Configure Product Settings for BU.
									Split = "even"
								} : null,

							}
						},
					}
					}
				};
				rawJson = JsonSerializer.Serialize(shipmentRequest, options);
			}
							string response = PostData(apiEndpoint, rawJson);

		}

		private static string PostData(string url, string rawJson)
		{
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
				client.DefaultRequestHeaders.Add("Accept", "application/json");
				HttpContent content = new StringContent(rawJson, Encoding.UTF8, "application/json");
				HttpResponseMessage response = client.PostAsync(url, content).GetAwaiter().GetResult();
				return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}
		}
	}
}