using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServiceReference.Ppl
{
    public class Models
    {
        public class ShipmentBatchRequest
        {
            [JsonProperty("returnChannel")]
            public ReturnChannel ReturnChannel { get; set; }

            [JsonProperty("labelSettings")]
            public LabelSettings LabelSettings { get; set; }

            [JsonProperty("shipments")]
            public List<Shipment> Shipments { get; set; }

            [JsonProperty("shipmentsOrderBy")]
            public string ShipmentsOrderBy { get; set; }
        }

        public class ShipmentBatchLabelRequest
        {
            [JsonProperty("labelSettings")]
            public LabelSettings LabelSettings { get; set; }
        }

        public class ReturnChannel
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }
        }

        public class LabelSettings
        {
            [JsonProperty("format")]
            public string Format { get; set; }

            [JsonProperty("dpi")]
            public int? Dpi { get; set; }

            [JsonProperty("completeLabelSettings")]
            public CompleteLabelSettings CompleteLabelSettings { get; set; }
        }

        public class CompleteLabelSettings
        {
            [JsonProperty("isCompleteLabelRequested")]
            public bool? IsCompleteLabelRequested { get; set; }

            [JsonProperty("pageSize")]
            public string PageSize { get; set; }

            [JsonProperty("position")]
            public int? Position { get; set; }
        }

        public class Shipment
        {
            [JsonProperty("productType")]
            public string ProductType { get; set; }

            [JsonProperty("recipient")]
            public Address Recipient { get; set; }

            [JsonProperty("referenceId")]
            public string ReferenceId { get; set; }

            [JsonProperty("shipmentNumber")]
            public string ShipmentNumber { get; set; }

            [JsonProperty("note")]
            public string Note { get; set; }

            [JsonProperty("depot")]
            public string Depot { get; set; }

            [JsonProperty("ageCheck")]
            public string AgeCheck { get; set; }

            [JsonProperty("integratorId")]
            public int? IntegratorId { get; set; }

            [JsonProperty("shipmentSet")]
            public ShipmentSet ShipmentSet { get; set; }

            [JsonProperty("backAddress")]
            public Address BackAddress { get; set; }

            [JsonProperty("sender")]
            public Address Sender { get; set; }

            [JsonProperty("senderMask")]
            public Address SenderMask { get; set; }

            [JsonProperty("specificDelivery")]
            public SpecificDelivery SpecificDelivery { get; set; }

            [JsonProperty("cashOnDelivery")]
            public Cod CashOnDelivery { get; set; }

            [JsonProperty("insurance")]
            public Insurance Insurance { get; set; }

            [JsonProperty("externalNumbers")]
            public List<ExternalNumber> ExternalNumbers { get; set; }

            [JsonProperty("services")]
            public List<Service> Services { get; set; }

            [JsonProperty("dormant")]
            public Dormant Dormant { get; set; }

            [JsonProperty("shipmentRouting")]
            public ShipmentRouting ShipmentRouting { get; set; }

            [JsonProperty("directInjection")]
            public DirectInjection DirectInjection { get; set; }

            [JsonProperty("labelService")]
            public LabelService LabelService { get; set; }
        }

        public class Address
        {
            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("zipCode")]
            public string ZipCode { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("name2")]
            public string Name2 { get; set; }

            [JsonProperty("street")]
            public string Street { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("contact")]
            public string Contact { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }
        }

        public class ShipmentSet
        {
            [JsonProperty("numberOfShipments")]
            public int? NumberOfShipments { get; set; }

            [JsonProperty("shipmentSetItems")]
            public List<ShipmentSetItem> ShipmentSetItems { get; set; }
        }

        public class ShipmentSetItem
        {
            [JsonProperty("shipmentNumber")]
            public string ShipmentNumber { get; set; }

            [JsonProperty("weighedShipmentInfo")]
            public WeighedShipmentInfo WeighedShipmentInfo { get; set; }

            [JsonProperty("externalNumbers")]
            public List<ExternalNumber> ExternalNumbers { get; set; }

            [JsonProperty("insurance")]
            public Insurance Insurance { get; set; }
        }

        public class WeighedShipmentInfo
        {
            [JsonProperty("weight")]
            public double? Weight { get; set; }
        }

        public class ExternalNumber
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("externalNumber")]
            public string Number { get; set; }
        }

        public class Insurance
        {
            [JsonProperty("insuranceCurrency")]
            public string Currency { get; set; }

            [JsonProperty("insurancePrice")]
            public double? Price { get; set; }
        }

        public class Service
        {
            [JsonProperty("code")]
            public string Code { get; set; }
        }

        public class Cod
        {
            [JsonProperty("codCurrency")]
            public string Currency { get; set; }

            [JsonProperty("codPrice")]
            public double? Price { get; set; }

            [JsonProperty("codVarSym")]
            public string VarSym { get; set; }

            [JsonProperty("iban")]
            public string Iban { get; set; }

            [JsonProperty("swift")]
            public string Swift { get; set; }

            [JsonProperty("specSymbol")]
            public string SpecSymbol { get; set; }

            [JsonProperty("account")]
            public string Account { get; set; }

            [JsonProperty("accountPre")]
            public string AccountPre { get; set; }

            [JsonProperty("bankCode")]
            public string BankCode { get; set; }
        }

        public class SpecificDelivery
        {
            [JsonProperty("specificDeliveryDate")]
            public DateTime? DeliveryDate { get; set; }

            [JsonProperty("specificDeliveryTimeFrom")]
            public DateTime? TimeFrom { get; set; }

            [JsonProperty("specificDeliveryTimeTo")]
            public DateTime? TimeTo { get; set; }

            [JsonProperty("specificTakeDate")]
            public DateTime? TakeDate { get; set; }

            [JsonProperty("parcelShopCode")]
            public string ParcelShopCode { get; set; }
        }

        public class Dormant
        {
            [JsonProperty("shipmentNumber")]
            public string ShipmentNumber { get; set; }

            [JsonProperty("note")]
            public string Note { get; set; }

            [JsonProperty("recipient")]
            public Address Recipient { get; set; }

            [JsonProperty("externalNumbers")]
            public List<ExternalNumber> ExternalNumbers { get; set; }

            [JsonProperty("services")]
            public List<Service> Services { get; set; }

            [JsonProperty("weighedShipmentInfo")]
            public WeighedShipmentInfo WeighedShipmentInfo { get; set; }
        }

        public class ShipmentRouting
        {
            [JsonProperty("inputRouteCode")]
            public string InputRouteCode { get; set; }
        }

        public class DirectInjection
        {
            [JsonProperty("directAddressing")]
            public bool? DirectAddressing { get; set; }

            [JsonProperty("gatewayZipCode")]
            public string GatewayZipCode { get; set; }

            [JsonProperty("gatewayCity")]
            public string GatewayCity { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }
        }

        public class LabelService
        {
            [JsonProperty("labelless")]
            public bool? Labelless { get; set; }
        }
    }
}