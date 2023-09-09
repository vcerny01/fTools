using System;
using fBarcode.Exceptions;
using System.Security.Cryptography;
using System.Text;
using fBarcode.Fichema;
using ServiceReference.Gls;

namespace fBarcode.WebServices
{
    public static class GlsApi
    {
        private static byte[] Sha512(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }
        private static string CheckErrors(ErrorInfo[] errorList)
        {
            if (errorList.Length != 0)
            {
                string message = "";
                foreach (ErrorInfo error in errorList)
                {
                    message += $"{error.ErrorCode}: {error.ErrorDescription}\n\n";
                }
                return message;
            }
            return null;
        }
        public static byte[] GetParcelLabel(GlsParcel parcel)
        {
            var client = new ParcelServiceClient();
            var request = new PrintLabelsRequest1()
            {
                Username = parcel.ApiUsername,
                Password = Sha512(parcel.ApiPassword),
                TypeOfPrinter = "Connect",
                ParcelList = new Parcel2[]
                {
                    new Parcel2()
                    {
                        ClientNumber = parcel.ClientNumber,
                        ClientReference = parcel.OrderNumber,
                        CODAmount = parcel.IsCashOnDelivery ? parcel.Price : null,
                        CODReference = parcel.IsCashOnDelivery ? parcel.VariableSymbol : null,
                        Content = "",
                        PickupDate = parcel.TransmissionDate,
                        Count = parcel.IsMultiParcel ? parcel.MultiParcelCount : 1,
                        PickupAddress = new Address1
                        {
                            // TODO Should be saved in settings or build config
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
                        DeliveryAddress = new Address1()
                        {
                            ContactName = String.Join(" ", parcel.recipient.FirstName, parcel.recipient.LastName),
                            ContactPhone = parcel.recipient.PhoneNumber,
                            ContactEmail = parcel.recipient.EmailAdress,
                            City = parcel.isParcelShop ? null : parcel.recipient.City,
                            Street = parcel.isParcelShop ? null : parcel.recipient.Street,
                            HouseNumber = parcel.isParcelShop ? null : parcel.recipient.HouseNumber,
                            CountryIsoCode = parcel.isParcelShop ? null : parcel.recipient.CountryIso,
                            ZipCode = parcel.isParcelShop ? null : parcel.recipient.PostalCode
                        },
                        ServiceList = parcel.isParcelShop ? new Service1[]
                        {
                            new Service1()
                            {
                                Code = "PSD",
                                PSDParameter = new ServiceParameterStringInteger1()
                                {
                                    StringValue = parcel.ParcelShopId
                                }
                            }
                        } : null,
                    }
                }
            };
            var response = client.PrintLabelsAsync(request).GetAwaiter().GetResult();
            var errorMessage = CheckErrors(response.PrintLabelsErrorList);
            if (errorMessage != null)
                throw new ApiOperationFailedException(parcel.OrderNumber, errorMessage);
            client.Close();
            return response.Labels;
        }
    }
}