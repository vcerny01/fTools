﻿using System;
using fBarcode.Fichema;
using ServiceReference.Zasilkovna;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using fBarcode.Exceptions;
using fBarcode.Logging;
using System.Net.Http;

namespace fBarcode.WebServices
{
    public static class ZasilkovnaApi
    {
        public static (byte[], string) GetParcelLabel(ZasilkovnaParcel parcel)
        {
			var createPacketRequest = new Models.CreatePacketRequest()
			{
				ApiPassword = AdminSettings.Zasilkovna.ApiPassword,
				PacketAttributes = new Models.PacketAttributes()
				{
					Number = parcel.VariableSymbol,
					Name = parcel.recipient.FirstName,
					Surname = parcel.recipient.LastName,
					Email = parcel.recipient.EmailAdress,
					Phone = parcel.recipient.PhoneNumber,
					AddressId = parcel.AdressId,
					Company = parcel.recipient.isCompany ? parcel.recipient.CompanyName : null,
					Value = parcel.Price,
					Eshop = AdminSettings.Zasilkovna.Eshop,
					Weight = Convert.ToDecimal(parcel.Weight),
					Cod = parcel.IsCashOnDelivery ? parcel.Price : 0
				}
			};
			string requestXml = SerializeToXmlString(createPacketRequest);
			string rawResponse = PostData(requestXml, parcel.OrderNumber);
			var createPacketResponse = DeserializeFromXmlString<Models.CreatePacketResponse>(rawResponse);
			if (createPacketResponse.Status == "ok")
			{
				ulong packetId = createPacketResponse.Result.Id;
				var createLabelRequest = new Models.PacketLabelPdfRequest()
				{
					ApiPassword = AdminSettings.Zasilkovna.ApiPassword,
					PacketId = packetId,
					Format = "A6 on A6",
					Offset = 0
				};
				rawResponse = PostData(SerializeToXmlString(createLabelRequest), parcel.OrderNumber);
				var labelResponse = DeserializeFromXmlString<Models.PacketLabelPdfResponse>(rawResponse);
				if (labelResponse.Status == "ok")
					return (Convert.FromBase64String(labelResponse.Result),createPacketResponse.Result.Id.ToString());
				else
					throw new ApiOperationFailedException(parcel.OrderNumber, rawResponse);
			}
			else
				throw new ApiOperationFailedException(parcel.OrderNumber, rawResponse);
        }
		private static string PostData(string rawXml, string orderNumber)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
				HttpContent httpContent = new StringContent(rawXml, Encoding.UTF8, "text/xml");
				HttpResponseMessage response = httpClient.PostAsync(AdminSettings.Zasilkovna.ApiUrl, httpContent).Result;
				if (response.IsSuccessStatusCode)
					return response.Content.ReadAsStringAsync().Result;					
				else
					throw new ApiOperationFailedException(orderNumber, $"HTTP code: {response.StatusCode}");
			}
		}
		private static string SerializeToXmlString<T>(T obj)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (MemoryStream memoryStream = new MemoryStream())
			{
				serializer.Serialize(memoryStream, obj);
				return Encoding.UTF8.GetString(memoryStream.ToArray());
			}
		}
		private static T DeserializeFromXmlString<T>(string xml)
		{
			using (var reader = new StringReader(xml))
			{
				var serializer = new XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(reader);
			}
		}
	}
}

