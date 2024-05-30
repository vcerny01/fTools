using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServiceReference.DpdNew
{
	public class Models
	{

		// EXTERNAL SHIPMENT REQUEST
		public class NewExternalShipmentRequest
		{
			public string BuCode { get; set; }
			public string CustomerId { get; set; }
			public List<ExternalShipmentRequestDTO> Shipments { get; set; }
		}
		public class ExternalShipmentRequestDTO
		{
			public string Depot { get; set; }
			public bool ExtendShipmentData { get; set; }
			public string FromTime { get; set; }
			public string LabelSize { get; set; }
			public ExternalShipmentMaskedAddressDTO MaskedSender { get; set; }
			public int NumOrder { get; set; }
			public List<ExternalShipmentParcelDTO> Parcels { get; set; }
			public string PickupDate { get; set; }
			public string PrintFormat { get; set; }
			public bool PrintRef1AsBarcode { get; set; }
			public ExternalShipmentReceiverAddressDTO Receiver { get; set; }
			public string Reference1 { get; set; }
			public string Reference2 { get; set; }
			public string Reference3 { get; set; }
			public string Reference4 { get; set; }
			public string OptionalDirectives { get; set; }
			public string SaveMode { get; set; }
			public ExternalShipmentSenderAddressDTO Sender { get; set; }
			public long SenderAddressId { get; set; }
			public CreationExternalShipmentServiceDTO Service { get; set; }
			public string ToTime { get; set; }
			public string OriginalCustomerId { get; set; }
			public ReturnConsolidationDTO ReturnConsolidation { get; set; }
			public InterDTO Inter { get; set; }
		}
		public class ExternalShipmentMaskedAddressDTO
		{
			public string City { get; set; }
			public string CompanyName { get; set; }
			public string CompanyName2 { get; set; }
			public string ContactEmail { get; set; }
			public string ContactFax { get; set; }
			public string ContactFaxPrefix { get; set; }
			public string ContactMobile { get; set; }
			public string ContactMobilePrefix { get; set; }
			public string ContactPhone { get; set; }
			public string ContactPhonePrefix { get; set; }
			public string CountryCode { get; set; }
			public string FlatNo { get; set; }
			public string HouseNo { get; set; }
			public string Name { get; set; }
			public string Name2 { get; set; }
			public string Street { get; set; }
			public string ZipCode { get; set; }
		}
		public class ExternalShipmentReceiverAddressDTO
		{
			public string AdditionalAddressInfo { get; set; }
			public string Address2 { get; set; }
			public string Address3 { get; set; }
			public string City { get; set; }
			public string CompanyName { get; set; }
			public string CompanyName2 { get; set; }
			public string ContactEmail { get; set; }
			public string ContactFax { get; set; }
			public string ContactFaxPrefix { get; set; }
			public string ContactInterphoneName { get; set; }
			public string ContactMobile { get; set; }
			public string ContactMobilePrefix { get; set; }
			public string ContactName { get; set; }
			public string ContactPhone { get; set; }
			public string ContactPhonePrefix { get; set; }
			public string CountryCode { get; set; }
			public string CountryName { get; set; }
			public string Department { get; set; }
			public string DoorCode { get; set; }
			public string FlatNo { get; set; }
			public string Floor { get; set; }
			public string HouseNo { get; set; }
			public string Name { get; set; }
			public string Name2 { get; set; }
			public string Street { get; set; }
			public string ZipCode { get; set; }
		}
		public class ExternalShipmentSenderAddressDTO
		{
			public string AdditionalAddressInfo { get; set; }
			public string Address2 { get; set; }
			public string Address3 { get; set; }
			public string City { get; set; }
			public string CompanyName { get; set; }
			public string CompanyName2 { get; set; }
			public string ContactEmail { get; set; }
			public string ContactFax { get; set; }
			public string ContactFaxPrefix { get; set; }
			public string ContactInterphoneName { get; set; }
			public string ContactMobile { get; set; }
			public string ContactMobilePrefix { get; set; }
			public string ContactName { get; set; }
			public string ContactPhone { get; set; }
			public string ContactPhonePrefix { get; set; }
			public string CountryCode { get; set; }
			public string CountryName { get; set; }
			public string Department { get; set; }
			public string DoorCode { get; set; }
			public string FlatNo { get; set; }
			public string Floor { get; set; }
			public string HouseNo { get; set; }
			public string Name { get; set; }
			public string Name2 { get; set; }
			public string Street { get; set; }
			public string ZipCode { get; set; }
		}
		public class ExternalShipmentParcelDTO
		{
			public double Weight { get; set; }
			public int DimensionWidth { get; set; }
			public int DimensionHeight { get; set; }
			public int DimensionLength { get; set; }
			public double CodAmount { get; set; }
			public double InsuranceAmount { get; set; }
			public bool LimitedQuantity { get; set; }
			public string Reference1 { get; set; }
			public string Reference2 { get; set; }
			public string Reference3 { get; set; }
			public string Reference4 { get; set; }
			public long ParcelId { get; set; }
			public string ParcelNumber { get; set; }
		}
		public class CreationExternalShipmentServiceDTO
		{
			public ExternalShipmentAdditionalServiceDTO AdditionalService { get; set; }
			public string MainServiceCode { get; set; }
			public List<string> MainServiceElementCodes { get; set; }
		}
		public class ExternalShipmentAdditionalServiceDTO
		{
			public List<ExternalAdditionalProductDTO> AdditionalProductList { get; set; }
			public ExternalCodDTO Cod { get; set; }
			public ExternalHighInsuranceDTO HighInsurance { get; set; }
			public IdCheckServiceDTO IdCheck { get; set; }
			public List<string> OtherAdditionalServiceElementCode { get; set; }
			public List<ExternalPredictDTO> Predicts { get; set; }
			public string PudoId { get; set; }
			public ReturnDTO ReturnService { get; set; }
			public RodDTO Rod { get; set; }
			public SwapDTO Swap { get; set; }
		}

		public class ExternalCodDTO
		{
			public string BIC { get; set; }
			public string IBAN { get; set; }
			public string AccountName { get; set; }
			public double Amount { get; set; }
			public string BankAccount { get; set; }
			public string BankAccountId { get; set; }
			public string BankCode { get; set; }
			public string BankName { get; set; }
			public string Currency { get; set; }
			public string PaymentType { get; set; }
			public string Reference { get; set; }
			public string Split { get; set; }
		}
		public class ExternalHighInsuranceDTO
		{
			public double Amount { get; set; }
			public string Currency { get; set; }
			public string Split { get; set; }
		}
		public class IdCheckServiceDTO
		{
			public string ReceiverId { get; set; }
			public string ReceiverName { get; set; }
		}
		public class ExternalPredictDTO
		{
			public string Destination { get; set; }
			public string DestinationType { get; set; }
			public string Language { get; set; }
			public string Trigger { get; set; }
			public string Type { get; set; }
		}
		public class ReturnDTO
		{
			public bool PrintReturnLabel { get; set; }
			public ExternalShipmentReceiverAddressDTO ReturnAddress { get; set; }
			public bool UseSenderAsReturnAddress { get; set; }
		}
		public class RodDTO
		{
			public string RodReference { get; set; }
		}
		public class SwapDTO
		{
			public long SwappedParcelNumber { get; set; }
		}
		public class ExternalAdditionalProductDTO
		{
			public List<string> Elements { get; set; }
			public string Name { get; set; }
			public List<string> NonOpsElements { get; set; }
		}
		public class ReturnConsolidationDTO
		{
			public ReturnDeportAddressDTO returnDepotAddress { get; set; }
			public string ReturnComment { get; set; }
			public long ReturnGln { get; set; }
			public string ReturnDepot { get; set; }
			public string ReturnPudoId { get; set; }
		}
		public class ReturnDeportAddressDTO
		{
			public string Name { get; set; } // Conditional, One of the two fields (name / companyName) is mandatory.
			public string Name2 { get; set; }
			public string CompanyName { get; set; } // Conditional, One of the two fields (name / companyName) is mandatory.
			public string CountryCode { get; set; } // Yes, Return depot country (ISO 3166 2-alpha code).
			public string ZipCode { get; set; } // Yes, Return address post code. Only Characters 0-9A-Z are allowed.
			public string City { get; set; } // Yes, Return address city/town.
			public string Street { get; set; } // Yes, Return address street.
			public string HouseNo { get; set; }
			public string FlatNo { get; set; }
			public string Address2 { get; set; }
			public string Address3 { get; set; }
			public string Department { get; set; }
			public string Floor { get; set; }
			public string DoorCode { get; set; }
			public string Building { get; set; }
			public string ContactName { get; set; }
			public string ContactPhonePrefix { get; set; }
			public string ContactPhone { get; set; }
			public string ContactFaxPrefix { get; set; }
			public string ContactFax { get; set; }
			public string ContactInterphoneName { get; set; }
			public string ContactEmail { get; set; }
			public string AdditionalAddressInfo { get; set; }
			public string Longitude { get; set; } // Geo. Longitude coordinate Number, according to ISO 6709. ± Degrees + decimal i.e DD.ddddddd
			public string Latitude { get; set; } // Geo. Latitude coordinate Number, according to ISO 6709. ± Degrees + decimal i.e DD.ddddddd
			public string StateCode { get; set; } // Conditional, according to country code.
		}
		public class InterDTO
		{
			public string ParcelType { get; set; } // Conditional, see description
			public double? CAmount { get; set; } // Conditional, see description
			public string Currency { get; set; } // Conditional, see description
			public double? CAmountEx { get; set; } // Conditional, see description
			public string CurrencyEx { get; set; } // Conditional, see description
			public string CTerms { get; set; } // Conditional, see description
			public string CPaper { get; set; }
			public string CComment { get; set; }
			public string ClearanceCleared { get; set; } // Yes, Clearancecleared Flag
			public string HighLowValue { get; set; } // Conditional, see description
			public string PreAlertStatus { get; set; } // Conditional, see description
			public string CInvoice { get; set; } // Conditional, see description
			public string CInvoiceDate { get; set; }
			public string CName1 { get; set; } // Conditional, see description
			public string CName2 { get; set; } // Conditional, see description
			public string CStreet { get; set; } // Conditional, see description
			public string CPropNum { get; set; }
			public string CCountryCode { get; set; } // Conditional, see description
			public string CState { get; set; } // Conditional, see description
			public string CZipCode { get; set; } // Conditional, see description
			public string CTown { get; set; }
			public string CGpsLat { get; set; }
			public string CGpsLong { get; set; }
			public string CContact { get; set; } // Conditional, see description
			public string SiPhonePrefix { get; set; }
			public string SiPhone { get; set; }
			public string CPhone { get; set; }
			public string CPhonePrefix { get; set; }
			public string CFax { get; set; }
			public string CFaxPrefix { get; set; }
			public string CEmail { get; set; } // Conditional, see description
			public long? CGln { get; set; }
			public string CVatNo { get; set; }
			public string CNumber { get; set; }
			public string ShipMrn { get; set; }
			public string CEori { get; set; }
			public string SiName1 { get; set; } // Conditional, see description
			public string SiName2 { get; set; } // Conditional, see description
			public string SiStreet { get; set; }
			public string SiPropNum { get; set; }
			public string SiCountryCode { get; set; }
			public string SiState { get; set; } // Conditional, see description
			public string SiZipCode { get; set; }
			public string SiTown { get; set; }
			public string SiGpsLat { get; set; }
			public string SiGpsLong { get; set; }
			public string SiContact { get; set; }
			public string SiEmail { get; set; } // Conditional, see description
			public string OpCode { get; set; } // Yes, The record is new, updated and deleted (INS, UPD, DEL)
			public int? NumberOfArticle { get; set; }
			public string DestCountryReg { get; set; } // Conditional, see description
			public string SiEori { get; set; }
			public string ReasonForExport { get; set; } // Yes, Reason for export
			public string SVatNo { get; set; }
			public string SEori { get; set; }
			public string RVatNo { get; set; }
			public string REori { get; set; }
			public InterInvoiceDTO InterInvoiceList { get; set; } // A list of Inter Invoice Lines
		}
		public class InterInvoiceDTO
		{
			public int? CInvoicePosition { get; set; }
			public int QItems { get; set; } // Yes, Quantity of items per article or invoice line
			public string CContent { get; set; } // Yes, Content (first 35 characters used by some systems)
			public double CAmountLine { get; set; } // Yes, Value of invoice position (number of decimals depend on currency)
			public string RcTarif { get; set; }
			public string COrigin { get; set; } // Yes, COUNTRYCODE of invoice origin (ISO 3166)
			public int? CNetWeight { get; set; } // Conditional, see description
			public int? CGrossWeight { get; set; } // Conditional, see description
			public string CProdCode { get; set; }
			public string CProdType { get; set; }
			public string CFabricComposition { get; set; } // Yes, Description of fabric composition
			public string RcTarifNumber { get; set; } // Yes, Customs tariff number (HSCODE)
			public string ScTarif { get; set; } // Yes, Customs tariff number (Mandatory according to origin country)
			public string GoodsWebPage { get; set; }
		}
		
		
		// EXTERNAL SHIPMENT RESPONSE TO DO


	}
}
