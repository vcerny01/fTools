using System;
using fBarcode.Exceptions;
using System.Collections.Generic;
using fBarcode.Logging;
using fBarcode.WebServices;
using System.ServiceModel.Channels;

namespace fBarcode.Fichema
{
	public abstract partial class Parcel
	{
		public int CourierNumber;
		public string CourierName;
		public string OrderNumber;
		public bool IsMultiParcel = false;
		public bool isParcelShop = false;
		public int MultiParcelCount;
		public bool IsEveningParcel = false;
		public bool IsCashOnDelivery;
		public double Weight = 1;
		public string VariableSymbol;
		public string Currency = "CZK";
		public decimal Price;
		public DateTime TransmissionDate = new DateTime(DateTime.Now.Ticks);
		public RecipientInfo recipient;

		public static Parcel createParcel(string orderNumber, ParcelPreferences parcelPreferences)
		{
			if (!PohodaService.hasOrder(orderNumber))
			{
				throw new OrderNotFoundException(orderNumber);
			}
			Dictionary<string, object> orderData = PohodaService.GetOrderData(orderNumber);
			int courierNumber = (int)orderData["RefDopravci"];
			switch (courierNumber)
				{
					case 10:
					case 14:
					case 15:
					case 16:
					case 18:
					case 19:
					case 22:
						return new CzechPostParcel(orderData, parcelPreferences);
					case 3:
					case 24:
						return new GlsParcel(orderData, parcelPreferences);
					case 7:
					case 25:
						return new DpdParcel(orderData, parcelPreferences);
					case 23:
						return new ZasilkovnaParcel(orderData, parcelPreferences);
					default:
						throw new CourierNotFoundException(orderNumber, courierNumber.ToString());
			}
		}
		protected Parcel(Dictionary<string, object> orderData, ParcelPreferences preferences)
		{
			try
			{
				OrderNumber = (string)orderData["Cislo"];
				IsEveningParcel = preferences.EveningParcel;
				CourierNumber = (int)orderData["RefDopravci"];
				if (CourierNumber > 22)
					isParcelShop = true;
				Weight = Double.Round((double)orderData["VPrHmotnost"],3);
				if (preferences.ForceMultiParcel || Weight > 24)
				{
					IsMultiParcel = true;
					MultiParcelCount = GetMultiParcelCount();
					if (MultiParcelCount == 1)
						IsMultiParcel = false;
					Weight /= MultiParcelCount;
				}
				IsCashOnDelivery = Convert.IsDBNull(orderData["RelForUh"]) ? false : RequiresCashOnDelivery((int)orderData["RelForUh"]);
				Price = (decimal)orderData["KcCelkem"];
				recipient = new RecipientInfo(orderData, isParcelShop);
			} catch (Exception e)
			{
				throw new OrderParameterNotFoundException((string)orderData["Cislo"], e.Message);
			}
			VariableSymbol = (string)orderData["VarSym"];
			if (IsEveningParcel)
			{
				Weight = 0;
				IsCashOnDelivery = false;
			}
		}
		public abstract byte[] GetLabel();
	}

	public class CzechPostParcel : Parcel
	{
		public string ParcelPrefix;
		public string TimeStamp;
		public bool isRr = false;
		public string PrimaryServiceNumber = AdminSettings.GetSettingValue("CzechPost.servicePrimary");
        public string CodServiceNumber = AdminSettings.GetSettingValue("CzechPost.serviceDobirka");
		public string RrServiceNumber = AdminSettings.GetSettingValue("CzechPost.serviceRr");
		public string MultiParcelService = AdminSettings.GetSettingValue("CzechPost.serviceVk");
		public int idForm = int.Parse(AdminSettings.GetSettingValue("CzechPost.idForm"));
		public string idCustomer = AdminSettings.GetSettingValue("CzechPost.idCustomer");
        public string idContract = AdminSettings.GetSettingValue("CzechPost.idContract");
		public int idLocation = int.Parse(AdminSettings.GetSettingValue("CzechPost.idLocation"));
		public string idExtTransaction = "1";
        public string PostingOfficeZipCode = AdminSettings.GetSettingValue("CzechPost.podaciPostaPSC");
		public List<string> services = new List<string>();

		public CzechPostParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "Česká pošta";
			ParcelPrefix = GetCzechPostParcelPrefix(CourierNumber);
			if (ParcelPrefix == "RR")
			{
				isRr = true;
				idForm = int.Parse(AdminSettings.GetSettingValue("idFormRr"));
			}
			TimeStamp = TransmissionDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz");
			services.Add(AdminSettings.GetSettingValue("CzechPost.servicePrimary"));
			if (IsMultiParcel)
				services.Add(AdminSettings.GetSettingValue("CzechPost.serviceVk"));
			if (IsCashOnDelivery)
				services.Add(AdminSettings.GetSettingValue("CzechPost.serviceDobirka"));
			if (isRr)
				services.Add(AdminSettings.GetSettingValue("CzechPost.serviceRr"));
			if (Weight > 26)
				services.Add("L");
			else
				services.Add("M");
		}

        public override byte[] GetLabel()
        {
			return CzechPostApi.GetParcelLabel(this);
        }
    }
	public class DpdParcel : Parcel
	{
		public string ParcelShopId;
		public long MainServiceCode = long.Parse(AdminSettings.GetSettingValue("Dpd.serviceMain"));
		public string ApiUsername = AdminSettings.GetSettingValue("Dpd.username");
		public string ApiPassword = AdminSettings.GetSettingValue("Dpd.password");
        public long PayerId = long.Parse(AdminSettings.GetSettingValue("Dpd.payerId"));
        public long SenderAddressId = long.Parse(AdminSettings.GetSettingValue("Dpd.senderAddressId"));
        public string ApplicationType = AdminSettings.GetSettingValue("Dpd.applicationType");
		public string PriceOption;
		public string ReferenceNumber;

		public DpdParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "DPD";
			if (isParcelShop)
			{
				isParcelShop = true;
				ParcelShopId = (string)orderData["Ulice2"];
				MainServiceCode = 50101;
			}
			if (IsCashOnDelivery)
				PriceOption = "WithPrice";
			else
				PriceOption = "WithoutPrice";
			ReferenceNumber = orderData["Cislo"] + "t" + TransmissionDate.ToString("HHmm");
		}
        public override byte[] GetLabel()
        {
			return null;
        }
    }
	public class ZasilkovnaParcel : Parcel
	{
		public string AdressId;
		public string SenderEshop = AdminSettings.GetSettingValue("Zasilkovna.eshop");
		public string ApiPassword = AdminSettings.GetSettingValue("Zasilkovna.apiPassword");

        public ZasilkovnaParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "Zásilkovna";
			AdressId = (string)orderData["Ulice2"];
		}
        public override byte[] GetLabel()
        {
            throw new NotImplementedException();
        }
    }
	public class GlsParcel : Parcel
	{
		public int ClientNumber = int.Parse(AdminSettings.GetSettingValue("Gls.clientNumber"));
        public string ApiUsername = AdminSettings.GetSettingValue("Gls.username");
		public string ApiPassword = AdminSettings.GetSettingValue("Gls.password");
		public string ParcelShopId;
	
		public GlsParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "GLS";
			if (isParcelShop)
				ParcelShopId = (string)orderData["Ulice2"];
		}
        public override byte[] GetLabel()
        {
			return GlsApi.GetParcelLabel(this);
        }
    }
}