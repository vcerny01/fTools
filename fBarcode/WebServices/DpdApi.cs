using System;
using fBarcode.Fichema;
using fBarcode.Exceptions;
using DpdReference;
using fBarcode.Logging;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Net.Http;
using System.Xml;
using System.Text.RegularExpressions;

namespace fBarcode.WebServices
{
    public static class DpdApi
   {
		private static string apiUrl = AdminSettings.Dpd.ApiUrl;
		private static string CheckErrors(ErrorVO error)
		{
			long errorCode = 0; errorCode = error.code;
			if (errorCode != 0)
			{
				return string.Join("\n", error.code, error.text);
			}
			return null;
		}
		public static (byte[], string) GetParcelLabel(DpdParcel parcel)
		{
			var parcelItems = new ParcelVO[parcel.IsMultiParcel ? parcel.MultiParcelCount : 1];
			for (int i = 0; i < parcelItems.Length; i++)
			{
				parcelItems[i] = new ParcelVO();
				parcelItems[i].parcelReferenceNumber = parcel.ReferenceNumber + "p" + i;
				parcelItems[i].weight = parcel.Weight;
			}
			var shipment = new createShipment()
			{
				wsLang = "EN",
				wsUserName = parcel.ApiUsername,
				wsPassword = parcel.ApiPassword,
				applicationType = parcel.ApplicationType,
				priceOption1 = parcel.IsCashOnDelivery ? "WithoutPrice" : "WithPrice",
				shipmentList = new ShipmentVO[]
			{
				new ShipmentVO()
				{
					mainServiceCode = parcel.MainServiceCode,
					shipmentReferenceNumber = parcel.ReferenceNumber,
					payerId = parcel.PayerId,
					senderAddressId = parcel.SenderAddressId,
					receiverName = string.Join(" ", parcel.recipient.FirstName, parcel.recipient.LastName),
					receiverFirmName = parcel.recipient.isCompany ? parcel.recipient.CompanyName : null,
					receiverCountryCode = parcel.recipient.CountryIso,
					receiverZipCode = parcel.recipient.PostalCode,
					receiverCity = parcel.recipient.City,
					receiverEmail = parcel.recipient.EmailAdress,
					receiverStreet = parcel.recipient.Street,
					receiverHouseNo = parcel.recipient.HouseNumber,
					receiverPhoneNo = parcel.recipient.PhoneNumber,
					additionalServices = new AdditionalServiceVO
					{
						parcelShop = parcel.isParcelShop ? new ParcelShopShipmentVO
						{
							parcelShopId = parcel.ParcelShopId,
						} : null,
						returnLabel = true,
						cod = parcel.IsCashOnDelivery ? new CodVO
						{
							currency = parcel.Currency,
							referenceNumber = parcel.VariableSymbol,
							amount = parcel.Price.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture),
						} : null
					},
						parcels = parcelItems
					}
				}
			};
			string rawRequest = SerializeToXmlString(shipment);
			rawRequest = WrapInSoapEnvelope(rawRequest);
			string rawResponse = PostData(rawRequest, "createShipment", parcel.OrderNumber);
			rawResponse = UnwrapSoapEnvelope(rawResponse);
			var createParcelResponse = DeserializeFromXmlString<createShipmentResponse>(rawResponse);
			ReferenceVO shipmentReference;
			try
			{
				var parcelId = createParcelResponse.result.resultList[0].parcelResultList[0].parcelReferenceNumber;
				shipmentReference = createParcelResponse.result.resultList[0].shipmentReference;
			} catch(System.NullReferenceException)
			{
				throw new ApiOperationFailedException(parcel.OrderNumber, rawResponse);
			}
			var label = new getShipmentLabel()
			{
				wsLang = "EN",
				wsUserName = parcel.ApiUsername,
				wsPassword = parcel.ApiPassword,
				applicationType = parcel.ApplicationType,
				shipmentReferenceList = new ReferenceVO[]
				{
					shipmentReference
				},
				printFormat1 = "A6",
				printOption1 =  "Pdf"
			};
			rawRequest = WrapInSoapEnvelope(SerializeToXmlString(label));
			rawResponse = PostData(rawRequest, "getShipmentLabel", parcel.OrderNumber);
			var getLabelResponse = DeserializeFromXmlString<getShipmentLabelResponse>(UnwrapSoapEnvelope(rawResponse));
			if (getLabelResponse.result.transactionId == 0)
				throw new ApiOperationFailedException(parcel.OrderNumber, rawResponse);
			else
				return (getLabelResponse.result.pdfFile,parcel.ReferenceNumber);
		}
		private static string WrapInSoapEnvelope(string xmlString)
		{
			string soapEnvelope = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ship=""http://it4em.yurticikargo.com.tr/eshop/shipment"">
									   <soapenv:Header/>
									   <soapenv:Body>
									{xmlString}
									   </soapenv:Body>
									</soapenv:Envelope>";

			return soapEnvelope;
		}

		private static string SerializeToXmlString<T>(T obj)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty); // Remove namespace declarations

			XmlWriterSettings settings = new XmlWriterSettings
			{
				OmitXmlDeclaration = true, // Omit the XML declaration
				Indent = true,
				NamespaceHandling = NamespaceHandling.OmitDuplicates
			};

			using (MemoryStream memoryStream = new MemoryStream())
			using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
			{
				serializer.Serialize(xmlWriter, obj);
				xmlWriter.Flush();
				return Encoding.UTF8.GetString(memoryStream.ToArray()).Replace("_x003A_", ":");
			}
		}
		private static string UnwrapSoapEnvelope(string soapXml)
		{
			XmlDocument soapDocument = new XmlDocument();
			soapDocument.LoadXml(soapXml);

			XmlNamespaceManager nsManager = new XmlNamespaceManager(soapDocument.NameTable);
			nsManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");

			XmlNode bodyNode = soapDocument.SelectSingleNode("//soapenv:Envelope/soapenv:Body", nsManager);

			if (bodyNode != null)
			{
				return bodyNode.InnerXml;
			}

			return null;
		}
		private static T DeserializeFromXmlString<T>(string xml)
		{
			// Remove namespaces from the XML
			string xmlWithoutNamespaces = RemoveNamespaces(xml);
			XmlSerializer serializer = new XmlSerializer(typeof(T));

			using (var stringReader = new StringReader(xmlWithoutNamespaces))
			{
				return (T)serializer.Deserialize(stringReader);
			}
		}

		// Helper function to remove namespaces from XML using string manipulation
		private static string RemoveNamespaces(string xml)
		{
			// Remove namespace declarations from opening tags
			string cleanedXml = Regex.Replace(xml, @"(xmlns:?[^=]*=[""][^""]*[""])", "");
			cleanedXml = Regex.Replace(cleanedXml, @"<[a-zA-Z0-9_]+:", "<");
			cleanedXml = Regex.Replace(cleanedXml, @"</[a-zA-Z0-9_]+:", "</");
			cleanedXml = Regex.Replace(cleanedXml, @"\s+xsi:nil=""true""", "");

			return cleanedXml;
		}
		public static string PostData(string requestXml, string operation, string orderNumber)
		{
			using (var httpClient = new HttpClient())
			{
					httpClient.DefaultRequestHeaders.Add("SOAPAction", operation);
					var content = new StringContent(requestXml, Encoding.UTF8, "text/xml");
					var response = httpClient.PostAsync(apiUrl, content).Result;

					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsStringAsync().Result;
						return result;
					}
					else
						throw new ApiOperationFailedException(orderNumber, response.Content.ReadAsStringAsync().Result);
			}
		}
	}
}


