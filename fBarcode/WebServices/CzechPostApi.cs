/*
 * TODO: - Fix CoD parcels
 *		 - Implementovat vícekusy  
 * 
*/

using System;
using Fichema = fBarcode.Fichema;
using fBarcode.Exceptions;
using IO.Swagger.CzechPost.Client;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System.Text.Json;
using IO.Swagger.CzechPost.Api;
using IO.Swagger.CzechPost.Model;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using fBarcode.Logging;

namespace fBarcode.WebServices
{
    public static class CzechPostApi
    {
		private const string apiUrl = @"https://b2b-test.postaonline.cz:444/restservices/ZSKService/v1/";
		private static string apiToken = @AdminSettings.CzechPost.ApiToken;//@"b79b16c2-2f77-450f-91a5-868c3c698a82";
		private static string secretKey = @AdminSettings.CzechPost.ApiKey; //@"dOJWwjp+BWqUcof3K+3OW6XGTnEpmWerx64TCNk0+0pZnonHdN99NFRIGaJSX0/HTtiu6AGYpKp0mjguzqp+wg==";
		//public static string customerId = AdminSettings.CzechPost.IdCustomer; // @"U066";
		//public static string postCode = AdminSettings.CzechPost.PodaciPostaPSC; //"10003";
		//public static string idContract = AdminSettings.CzechPost.IdContract; //"256712001";


		public static byte[] GetParcelLabel(Fichema.CzechPostParcel fParcel)
		{
			Configuration config = new Configuration();
			config.BasePath = apiUrl;
			var client = new ParcelDataApi(config);
			var request = new ParcelServiceRequest(GenerateParcelServiceHeader(fParcel), GenerateParcelData(fParcel));
			//File.WriteAllText("something.txt", JsonConvert.SerializeObject(request));
			var headers = GenerateHeaders(HttpMethod.Post, request);
			foreach (var header in headers)
			{
				config.AddDefaultHeader(header.Key, header.Value);
			}
			ParcelServiceResponse response = null;
            response = client.SendParcelService(request, fParcel.idContract);
			var file = response.ResponseHeader.ResponsePrintParams.File;
			if (file == null)
				throw new ApiOperationFailedException(fParcel.OrderNumber, response.ToString());
			else
				return file;
		}

		private static ParcelServiceHeader GenerateParcelServiceHeader(fBarcode.Fichema.CzechPostParcel fParcel)
		{				
			return new ParcelServiceHeader()
			{
				ParcelServiceHeaderCom = new LetterHeader()
				{
					CustomerID = fParcel.idCustomer,
					PostCode = fParcel.PostingOfficeZipCode,
					LocationNumber = fParcel.idLocation,
					TransmissionDate = fParcel.TransmissionDate,
                },
                PrintParams = new PrintParams()
                {
                    IdForm = fParcel.idForm,
					ShiftHorizontal = 0,
					ShiftVertical = 0
                }
            };
        }
        private static ParcelData GenerateParcelData(Fichema.CzechPostParcel fParcel)
        {
	         var services = new Services();
            foreach (string service in fParcel.services)
                services.Add(service);

			return new ParcelData()
			{
				ParcelParams = new ParcelParams()
				{
					RecordID = "1",
                    PrefixParcelCode = fParcel.ParcelPrefix,
                    Weight = fParcel.Weight.ToString("0.000", CultureInfo.InvariantCulture),
                    InsuredValue = Convert.ToDouble(fParcel.Price),
                    Amount = fParcel.IsCashOnDelivery ? Convert.ToDouble(fParcel.Price) : null,
                    Currency = fParcel.Currency,
                    VsVoucher = fParcel.VariableSymbol,
					VsParcel = fParcel.VariableSymbol,
                    QuantityParcel = fParcel.IsMultiParcel ? fParcel.MultiParcelCount : 1,
					SequenceParcel = fParcel.IsMultiParcel ? 1 : 1
                },
                ParcelServices = services,
                ParcelAddress = new ParcelAddress()
                {
                    FirstName = fParcel.recipient.FirstName,
                    Surname = fParcel.recipient.LastName,
                    //Company = fParcel.recipient.isCompany ? $"{fParcel.recipient.CompanyName} ({fParcel.recipient.FirstName} {fParcel.recipient.LastName})" : null,
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
            headers.Add("Authorization-Content-SHA256", contentHash);

            // Generate HMAC_SHA256_Auth
            var nonce = Guid.NewGuid().ToString();
            var signature = CalculatePostSignature(contentHash, timestamp, nonce);
            headers.Add("Authorization", $"CP-HMAC-SHA256 nonce=\"{nonce}\" signature=\"{signature}\"");

            // Add API Key header
            headers.Add("Api-Token", apiToken);

            return headers;
        }
		private static string CalculateSHA256Hash(ParcelServiceRequest requestBody)
		{
			if (requestBody == null)
				return string.Empty;

			var json = JsonConvert.SerializeObject(requestBody);
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
		private static string CalculatePostSignature(string contentSha256, string timestamp, string nonce)
		{
			string dataToSign = $"{contentSha256};{timestamp};{nonce}";
			using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
			{
				var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(dataToSign));
				return Convert.ToBase64String(hashBytes);
			}
		}
	}
}
