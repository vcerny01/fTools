using System;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using fBarcode.Fichema;
using fBarcode.Exceptions;
using fBarcode.Logging;

namespace fBarcode.WebServices
{
	/// <summary>
	/// Packeta REST/XML API integration (replaces ZasilkovnaApi).
	///
	/// Pick-up point flow:
	///   1. createPacket        → packetId
	///   2. packetLabelPdf      → Packeta label PDF (base64)
	///
	/// Home delivery flow:
	///   1. createPacket        → packetId  (includes street, houseNumber, city, zip)
	///   2. packetCourierNumberV2 → courier tracking number
	///   3. packetCourierLabelPdf → carrier direct label PDF (base64)
	/// </summary>
	public static class PacketaApi
	{
		private static string ApiUrl => AdminSettings.Zasilkovna.ApiUrl;
		private static string ApiPassword => AdminSettings.Zasilkovna.ApiPassword;

		/// <summary>
		/// Creates a packet and returns (labelPdf, packetId).
		/// Uses the carrier's direct label for home delivery, Packeta label for pick-up points.
		/// </summary>
		public static (byte[], string) GetParcelLabel(ZasilkovnaParcel parcel)
		{
			ulong packetId = CreatePacket(parcel);

			if (parcel.IsHomeDelivery)
			{
				string courierNumber = GetCourierNumber(packetId, parcel.OrderNumber);
				byte[] label = GetCourierLabelPdf(packetId, courierNumber, parcel.OrderNumber);
				return (label, packetId.ToString());
			}
			else
			{
				byte[] label = GetPacketLabelPdf(packetId, parcel.OrderNumber);
				return (label, packetId.ToString());
			}
		}

		// ── Step 1: createPacket ────────────────────────────────────────

		private static ulong CreatePacket(ZasilkovnaParcel parcel)
		{
			var attrs = new XElement("packetAttributes",
				new XElement("number", parcel.VariableSymbol),
				new XElement("name", parcel.recipient.FirstName),
				new XElement("surname", parcel.recipient.LastName),
				new XElement("email", parcel.recipient.EmailAdress),
				new XElement("phone", parcel.recipient.PhoneNumber),
				new XElement("addressId", parcel.AdressId),
				new XElement("value", parcel.Price),
				new XElement("weight", Convert.ToDecimal(parcel.Weight)),
				new XElement("eshop", AdminSettings.Zasilkovna.Eshop)
			);

			if (parcel.recipient.isCompany)
				attrs.Add(new XElement("company", parcel.recipient.CompanyName));

			if (parcel.IsCashOnDelivery)
				attrs.Add(new XElement("cod", parcel.Price));

			if (parcel.IsHomeDelivery)
			{
				attrs.Add(new XElement("street", parcel.recipient.Street));
				attrs.Add(new XElement("houseNumber", parcel.recipient.HouseNumber));
				attrs.Add(new XElement("city", parcel.recipient.City));
				attrs.Add(new XElement("zip", parcel.recipient.PostalCode));
			}

			var requestXml = new XElement("createPacket",
				new XElement("apiPassword", ApiPassword),
				attrs
			);

			XElement response = PostAndParse(requestXml, parcel.OrderNumber);
			return ulong.Parse(
				response.Element("result")?.Element("id")?.Value
				?? throw new ApiOperationFailedException(parcel.OrderNumber, "Missing packet id in response"));
		}

		// ── Step 2a: packetCourierNumberV2 (home delivery) ──────────────

		private static string GetCourierNumber(ulong packetId, string orderNumber)
		{
			var requestXml = new XElement("packetCourierNumberV2",
				new XElement("apiPassword", ApiPassword),
				new XElement("packetId", packetId)
			);

			XElement response = PostAndParse(requestXml, orderNumber);
			return response.Element("result")?.Element("courierNumber")?.Value
				?? throw new ApiOperationFailedException(orderNumber, "Missing courier number in response");
		}

		// ── Step 2b: packetCourierLabelPdf (home delivery) ──────────────

		private static byte[] GetCourierLabelPdf(ulong packetId, string courierNumber, string orderNumber)
		{
			var requestXml = new XElement("packetCourierLabelPdf",
				new XElement("apiPassword", ApiPassword),
				new XElement("packetId", packetId),
				new XElement("courierNumber", courierNumber)
			);

			XElement response = PostAndParse(requestXml, orderNumber);
			string base64 = response.Element("result")?.Value
				?? throw new ApiOperationFailedException(orderNumber, "Missing label data in response");

			return Convert.FromBase64String(base64);
		}

		// ── Step 2c: packetLabelPdf (pick-up point) ─────────────────────

		private static byte[] GetPacketLabelPdf(ulong packetId, string orderNumber)
		{
			var requestXml = new XElement("packetLabelPdf",
				new XElement("apiPassword", ApiPassword),
				new XElement("packetId", packetId),
				new XElement("format", "A6 on A6"),
				new XElement("offset", 0)
			);

			XElement response = PostAndParse(requestXml, orderNumber);
			string base64 = response.Element("result")?.Value
				?? throw new ApiOperationFailedException(orderNumber, "Missing label data in response");

			return Convert.FromBase64String(base64);
		}

		// ── HTTP helper ─────────────────────────────────────────────────

		private static XElement PostAndParse(XElement requestXml, string orderNumber)
		{
			using var client = new HttpClient();
			var content = new StringContent(
				requestXml.ToString(SaveOptions.DisableFormatting),
				Encoding.UTF8,
				"text/xml"
			);

			HttpResponseMessage httpResponse = client.PostAsync(ApiUrl, content).Result;
			if (!httpResponse.IsSuccessStatusCode)
				throw new ApiOperationFailedException(orderNumber,
					$"HTTP {(int)httpResponse.StatusCode}: {httpResponse.ReasonPhrase}");

			string responseBody = httpResponse.Content.ReadAsStringAsync().Result;
			XElement response = XElement.Parse(responseBody);

			string status = response.Element("status")?.Value;
			if (status != "ok")
				throw new ApiOperationFailedException(orderNumber, responseBody);

			return response;
		}
	}
}