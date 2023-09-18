using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace ServiceReference.Zasilkovna
{
	public  class Models
	{
		[XmlRoot("createPacket")]
		public class CreatePacketRequest
		{
			[XmlElement("apiPassword")]
			public string ApiPassword { get; set; }

			[XmlElement("packetAttributes")]
			public PacketAttributes PacketAttributes { get; set; }
		}
		[XmlRoot("PacketAttributes")]
		public class PacketAttributes
		{
			[XmlElement("id")]
			public ulong Id { get; set; }

			[XmlElement("number")]
			public string Number { get; set; }

			[XmlElement("name")]
			public string Name { get; set; }

			[XmlElement("surname")]
			public string Surname { get; set; }

			[XmlElement("company")]
			public string Company { get; set; }

			[XmlElement("email")]
			public string Email { get; set; }

			[XmlElement("phone")]
			public string Phone { get; set; }

			[XmlElement("addressId")]
			public uint AddressId { get; set; }

			[XmlElement("currency")]
			public string Currency { get; set; }

			[XmlElement("cod")]
			public decimal Cod { get; set; }

			[XmlElement("value")]
			public decimal Value { get; set; }

			[XmlElement("weight")]
			public decimal Weight { get; set; }

			[XmlElement("deliverOn")]
			public DateTime? DeliverOn { get; set; }

			[XmlElement("eshop")]
			public string Eshop { get; set; }

			[XmlElement("adultContent")]
			public bool AdultContent { get; set; }

			[XmlElement("note")]
			public string Note { get; set; }

			[XmlElement("street")]
			public string Street { get; set; }

			[XmlElement("houseNumber")]
			public string HouseNumber { get; set; }

			[XmlElement("city")]
			public string City { get; set; }

			[XmlElement("province")]
			public string Province { get; set; }

			[XmlElement("zip")]
			public string Zip { get; set; }

			[XmlElement("carrierService")]
			public string CarrierService { get; set; }

			[XmlElement("customerBarcode")]
			public string CustomerBarcode { get; set; }

			[XmlElement("carrierPickupPoint")]
			public string CarrierPickupPoint { get; set; }

			// Other elements I don't need so I don't care to define them
			//[XmlElement("CustomsDeclaration")]
			//public CustomsDeclaration CustomsDeclaration { get; set; }

			//[XmlElement("Size")]
			//public Size Size { get; set; }

			//[XmlElement("AttributeCollection")]
			//public AttributeCollection AttributeCollection { get; set; }

			//[XmlElement("ItemCollection")]
			//public ItemCollection Items { get; set; }

			//[XmlElement("Security")]
			//public Security Security { get; set; }
		}
		[XmlRoot("response")]
		public class CreatePacketResponse
		{
			[XmlElement("status")]
			public string Status { get; set; }

			[XmlElement("result")]
			public Result Result { get; set; }
		}
		public class Result
		{
			[XmlElement("id")]
			public ulong Id { get; set; }

			[XmlElement("barcode")]
			public string Barcode { get; set; }

			[XmlElement("barcodeText")]
			public string BarcodeText { get; set; }
		}

		[XmlRoot("packetLabelPdf")]
		public class PacketLabelPdfRequest
		{
			[XmlElement("apiPassword")]
			public string ApiPassword { get; set; }

			[XmlElement("packetId")]
			public ulong PacketId { get; set; }

			[XmlElement("format")]
			public string Format { get; set; }

			[XmlElement("offset")]
			public int Offset { get; set; }
		}
		[XmlRoot("response")]
		public class PacketLabelPdfResponse
		{
			[XmlElement("status")]
			public string Status { get; set; }

			[XmlElement("result")]
			public string Result { get; set; }
		}
	}
}
