using System;
using Fichema = fBarcode.Fichema;
using fBarcode.Exceptions;
using IO.Swagger.CzechPost.Client;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using IO.Swagger.CzechPost.Api;
using IO.Swagger.CzechPost.Model;
using System.Windows.Forms;

namespace fBarcode.WebServices
{
    public static class CzechPostApi
    {
		private const string apiUrl = @"https://b2b-test.postaonline.cz:444/restservices/ZSKService/v1/";
		private const string apiKey = @"b79b16c2-2f77-450f-91a5-868c3c698a82";
		private const string secretKey = @"/qzdUBd3JnRFOcpLJNVdKGNi4sq2XpMGIMpl51bQ4XhXSc4FEZKzIxoPhbxLO4wk9hknaJjo4NEcyc2XK5JUYA==";
		public const string customerId = @"U114";
		public const string postCode = "77072";


		public static byte[] GetParcelLabel(Fichema.CzechPostParcel fParcel)
		{
			Configuration config = new Configuration();
			config.BasePath = apiUrl;
			var client = new ParcelDataApi(config);
			var request = new ParcelServiceRequest(GenerateParcelServiceHeader(fParcel), GenerateParcelData(fParcel));
			MessageBox.Show(request.ToString());
			var headers = GenerateHeaders(HttpMethod.Post, request);
			foreach (var header in headers)
			{
				config.AddDefaultHeader(header.Key, header.Value);
			}
			ParcelServiceResponse response = null;
            response = client.SendParcelService(request, null);
			var file = response.ResponseHeader.ResponsePrintParams.File;
			if (file == null)
				throw new ApiOperationFailedException(fParcel.OrderNumber, response.ToString());
			else
				return file;
		}

		private static ParcelServiceHeader GenerateParcelServiceHeader(fBarcode.Fichema.CzechPostParcel fParcel)
		{
			MessageBox.Show(fParcel.TransmissionDate.ToShortTimeString());
				
			return new ParcelServiceHeader()
			{
				ParcelServiceHeaderCom = new LetterHeader()
				{
					ContractNumber = fParcel.idContract,
					CustomerID = fParcel.idCustomer,
					PostCode = fParcel.PostingOfficeZipCode,
					LocationNumber = fParcel.idLocation,
					TransmissionDate = fParcel.TransmissionDate
                },
                PrintParams = new PrintParams()
                {
                    IdForm = fParcel.idForm,
                    ShiftHorizontal = fParcel.labelShiftHorizonal,
                    ShiftVertical = fParcel.labelShiftVertical
                }
            };
        }
        private static ParcelData GenerateParcelData(Fichema.CzechPostParcel fParcel)
        {
            var services = new IO.Swagger.CzechPost.Model.Services();
            foreach (string service in fParcel.services)
                services.Add(service);

			return new ParcelData()
			{
				ParcelParams = new ParcelParams()
				{
					RecordID = "1",
                    PrefixParcelCode = fParcel.ParcelPrefix,
                    Weight = fParcel.Weight.ToString("0.00"),
                    InsuredValue = Convert.ToDouble(fParcel.Price),
                    Amount = fParcel.IsCashOnDelivery ? Convert.ToDouble(fParcel.Price) : null,
                    Currency = fParcel.Currency,
                    VsVoucher = fParcel.VariableSymbol,
                    QuantityParcel = fParcel.MultiParcelCount,
                },
                ParcelServices = services,
                ParcelAddress = new ParcelAddress()
                {
                    FirstName = fParcel.recipient.FirstName,
                    Surname = fParcel.recipient.LastName,
                    Company = fParcel.recipient.isCompany ? fParcel.recipient.CompanyName : null,
                    Subject = fParcel.recipient.isCompany ? "P" : "F",
                    PhoneNumber = fParcel.recipient.PhoneNumber,
                    EmailAddress = fParcel.recipient.EmailAdress,
                    Address = new AddressCOMMON
                    {
                        IsoCountry = fParcel.recipient.CountryIso,
                        City = fParcel.recipient.City,
                        ZipCode = fParcel.recipient.PostalCode,
                        Street = fParcel.recipient.Street,
                        HouseNumber = fParcel.recipient.HouseNumber,
                    },
                }
            };
        }

        private static Dictionary<string, string> GenerateHeaders(HttpMethod method, ParcelServiceRequest requestBody)
        {
            var headers = new Dictionary<string, string>();

            // Generate Authorization-Timestamp
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            headers.Add("Authorization-Timestamp", timestamp);

            // Generate Authorization-Content-SHA256
            var contentHash = CalculateSHA256Hash(requestBody);
            headers.Add("Authorization-Content-SHA256", requestBody.GetHashCode().ToString());

            // Generate HMAC_SHA256_Auth
            var nonce = Guid.NewGuid().ToString();
            var signature = GenerateHMACSignature(method, contentHash, timestamp, nonce);
            headers.Add("Authorization", $"CP-HMAC-SHA256 nonce=\"{nonce}\" signature=\"{signature}\"");

            // Add API Key header
            headers.Add("Api-Token", apiKey);

            return headers;
        }

        private static string CalculateSHA256Hash(ParcelServiceRequest requestBody)
        {
            if (requestBody == null)
                return string.Empty;

            var json = requestBody.ToJson();
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private static string GenerateHMACSignature(HttpMethod method, string contentHash, string timestamp, string nonce)
        {
            var data = $"{contentHash};{timestamp};{nonce}";
            if (method == HttpMethod.Get)
                data = $";{timestamp};{nonce}";

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(signatureBytes);
            }
        }
    }
}
