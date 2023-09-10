using System;
using fBarcode.Fichema;
using fBarcode.Exceptions;
using ServiceReference.Dpd;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;


namespace fBarcode.WebServices
{
    public static class DpdApi
    {
        private static string CheckErrors(ErrorVO error)
        {
            long errorCode = 0; errorCode = error.code;
            if (errorCode != 0)
            {
                return string.Join("\n", error.code, error.text);
            }
            return null;
        }
        public static byte[] GetParcelLabel(DpdParcel parcel)
        {
			var parcelItems = new ParcelVO[parcel.IsMultiParcel ? parcel.MultiParcelCount : 1];
			MessageBox.Show(parcelItems.Length.ToString());

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
                priceOption = parcel.IsCashOnDelivery ? shipmentPriceOption.WithPrice : shipmentPriceOption.WithoutPrice,
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
                            cod = new CodVO
                            {
                                currency = parcel.Currency,
                                amount = Convert.ToDouble(parcel.Price),
                            }
                        },
                        parcels = parcelItems
                    }
                }
            };

			var client = new ShipmentServiceImplClient();
			var responseShipment = client.createShipmentAsync(shipment).GetAwaiter().GetResult();
			string errorMessage = CheckErrors(responseShipment.createShipmentResponse.result.resultList[0].error);
            if (errorMessage != null)
            {
                throw new ApiOperationFailedException(parcel.OrderNumber, errorMessage);
            }
            var shipmentId = responseShipment.createShipmentResponse.result.resultList[0].shipmentReference.id;

            var label = new getShipmentLabel()
            {
                wsUserName = parcel.ApiUsername,
                wsPassword = parcel.ApiPassword,
                wsLang = "EN",
                applicationType = parcel.ApplicationType,
                shipmentReferenceList = new ReferenceVO[]
                {
                    new ReferenceVO
                    {
                        id = shipmentId,
                        referenceNumber = parcel.ReferenceNumber
                    }
                },
                printFormat = printFormat.A6,
                printOption = printOption.Pdf
            };
            var responseLabel = client.getShipmentLabelAsync(label).GetAwaiter().GetResult();
            errorMessage = CheckErrors(responseShipment.createShipmentResponse.result.resultList[0].error);
            if (errorMessage != null)
            {
                throw new ApiOperationFailedException(parcel.OrderNumber, errorMessage);
            }
            client.Close();
            return responseLabel.getShipmentLabelResponse.result.pdfFile;
        }
    }
}

