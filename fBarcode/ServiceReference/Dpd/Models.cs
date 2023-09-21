using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace fBarcode.ServiceReference.Dpd
{
	public class Models
	{
		public Models()
		{
            [XmlRoot(ElementName = "createShipment", Namespace = "http://yournamespace.com")]
            public class CreateShipment
        {
            public string wsUserName { get; set; }
            public string wsPassword { get; set; }
            public string wsLang { get; set; }
            public string applicationType { get; set; }
            public string businessApplication { get; set; }
            public List<ShipmentVO> shipmentList { get; set; }
            public ShipmentPriceOption priceOption { get; set; }
        }

        public class ShipmentVO
        {
            public long? shipmentId { get; set; }
            public string shipmentReferenceNumber { get; set; }
            public string shipmentReferenceNumber1 { get; set; }
            public string shipmentReferenceNumber2 { get; set; }
            public string shipmentReferenceNumber3 { get; set; }
            public long payerId { get; set; }
            public long senderAddressId { get; set; }
            public string receiverName { get; set; }
            public string receiverFirmName { get; set; }
            public string receiverCountryCode { get; set; }
            public string receiverZipCode { get; set; }
            public string receiverCity { get; set; }
            public string receiverStreet { get; set; }
            public string receiverHouseNo { get; set; }
            public string receiverPhoneNo { get; set; }
            public string receiverEmail { get; set; }
            public string receiverAdditionalAddressInfo { get; set; }
            public long mainServiceCode { get; set; }
            public AdditionalServiceVO additionalServices { get; set; }
            public List<ParcelVO> parcels { get; set; }
            public string returnAddressSubzoneId { get; set; }
            public string returnAddressContactName { get; set; }
            public string returnAddressReferenceNumber { get; set; }
            public string returnAddressEmailAddress { get; set; }
            public string returnAddressTelArea { get; set; }
            public string returnAddressAdditionalAdrInfo { get; set; }
            public long? returnAddressTownId { get; set; }
            public long? returnAddressCustId { get; set; }
            public long? returnAddressAdrId { get; set; }
            public string returnAddressZipCode { get; set; }
            public long? returnAddressCountryId { get; set; }
            public long? returnAddressAreaId { get; set; }
            public long? returnAddressZoneId { get; set; }
            public long? returnAddressCityId { get; set; }
            public string returnAddressCity { get; set; }
            public string returnAddressFirmName { get; set; }
            public string returnAddressName { get; set; }
            public string returnAddressTaxNo { get; set; }
            public string returnAddressAddressText { get; set; }
            public string returnAddressTelNo { get; set; }
            public long? returnAddressStateId { get; set; }
            public string returnAddressHouseNo { get; set; }
            public string returnAddressIdType { get; set; }
            public string returnAddressIdNumber { get; set; }
            public string returnAddressIdIssuedPlace { get; set; }
            public string returnAddressCustType { get; set; }
            public string differentReturnAddress { get; set; }
        }

        public class AdditionalServiceVO
        {
            // Define properties for AdditionalServiceVO as needed
        }

        public class ParcelVO
        {
            // Define properties for ParcelVO as needed
        }

        public enum ShipmentPriceOption
        {
            WithPrice,
            WithoutPrice
        }
    }
	}
}

