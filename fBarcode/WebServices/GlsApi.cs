using System;
using fBarcode.Exceptions;
using System.Security.Cryptography;
using System.Text;
using fBarcode.Fichema;
using GLS.MyGLS.ServiceData.APIDTOs.LabelOperations;
using gParcel = GLS.MyGLS.ServiceData.APIDTOs.LabelOperations.Parcel;
using fParcel = fBarcode.Fichema.Parcel;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using fBarcode.Logging;


namespace fBarcode.WebServices
{
    public static class GlsApi
    {
        public static (byte[], string) GetParcelLabel(GlsParcel fParcel)
        {
            var request = new PrintLabelsRequest()
            {
                Username = fParcel.ApiUsername,
                Password = Sha512(fParcel.ApiPassword),
                TypeOfPrinter = "Connect",
                ParcelList = PrepareParcelData(fParcel)
            };
            string rawResponse = PostData("PrintLabels", SerializeFromObject(request, false), false, AdminSettings.Gls.ApiUrl);
            var response = DeserializeToObject<PrintLabelsResponse>(rawResponse, false);
            if (response != null && response.PrintLabelsErrorList.Count == 0 && response.Labels.Length > 0)
                return (response.Labels, response.PrintLabelsInfoList[0].ParcelNumber.ToString());
            else
                throw new ApiOperationFailedException(fParcel.OrderNumber, response.ToString());
        }
        private static List<gParcel> PrepareParcelData(GlsParcel fParcel)
        {
            return new List<gParcel>()
            {
                new gParcel()
                {
                    ClientNumber = fParcel.ClientNumber,
                    ClientReference = fParcel.OrderNumber,
                    CODAmount = fParcel.IsCashOnDelivery? fParcel.Price : null,
                    CODReference = fParcel.IsCashOnDelivery ? fParcel.VariableSymbol : null,
                    Count = fParcel.IsMultiParcel ? fParcel.MultiParcelCount : 1,
                    PickupDate = DateTime.Now,
                    // TODO: Outsource to config
                    PickupAddress = new Address()
                    {
                        ContactName = "Fichema",
                        ContactPhone = "722901440",
                        ContactEmail = "objednavky@fichema.cz",
                        Name = "Fichema",
                        Street = "Úlehlova",
                        HouseNumber = "8",
                        City = "Brno",
                        ZipCode = "62800",
                        CountryIsoCode = "CZ",
                        HouseNumberInfo = " budova 8"
                    },
                    DeliveryAddress = new Address()
                    {
                        ContactName = string.Join(" ", fParcel.recipient.FirstName, fParcel.recipient.LastName, fParcel.recipient.isCompany ? fParcel.recipient.CompanyName : null),
                        ContactEmail = fParcel.recipient.EmailAdress,
                        ContactPhone = fParcel.recipient.PhoneNumber,
                        Street = fParcel.isParcelShop ? fParcel.recipient.Street : null,
                        HouseNumber = fParcel.isParcelShop ? fParcel.recipient.HouseNumber : null,
                        ZipCode = fParcel.isParcelShop ? fParcel.recipient.PostalCode : null,
                        CountryIsoCode = fParcel.isParcelShop ? fParcel.recipient.CountryIso : null,
                    },
                    ServiceList = new List<Service>
                    {
                        fParcel.isParcelShop ? new Service()
                        {
                            Code = "PSD",
                            PSDParameter = new ServiceParameterStringInteger() { StringValue = fParcel.ParcelShopId }
                        } : null
                    }
                }
            };
        }
        private static string PostData(string methodName, string data, bool isXmlFormat, string url)
        {
            string format = isXmlFormat ? "xml" : "json";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = new Uri(url + "ParcelService" + ".svc" + $"/{format}/{methodName}");
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(uri, content).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;
                else
                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }
        private static byte[] Sha512(string input)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }
        private static string SerializeFromObject(object obj, bool isXmlFormat)
        {
            string data = string.Empty;
            if (obj == null)
                return data;
            XmlObjectSerializer serializer = isXmlFormat ? (XmlObjectSerializer)new DataContractSerializer(obj.GetType()) : new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream msObj = new MemoryStream())
            {
                serializer.WriteObject(msObj, obj);
                return Encoding.UTF8.GetString(msObj.ToArray());
            }
            // Not catching exceptions
        }
        private static T DeserializeToObject<T>(string data, bool isXmlFormat)
        {
            T result = default(T);
            if (data == null)
                return result;
            XmlObjectSerializer serializer = isXmlFormat ? (XmlObjectSerializer)new DataContractSerializer(typeof(T)) : new DataContractJsonSerializer(typeof(T));
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(data ?? "")))
            {
                result = (T)serializer.ReadObject(stream);
            }
            return result;
        }
    }
}