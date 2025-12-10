using System;
using fBarcode.Exceptions;
using System.Collections.Generic;
using fBarcode.Logging;
using fBarcode.WebServices;
using fBarcode.UI.Dialogs;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;

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
				// Zasilkovna domu
				case 26:
					return new ZasilkovnaParcel(orderData, parcelPreferences);
				case 26:
				case 27:
					return new PplParcel(orderData, parcelPreferences);
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
				if (CourierNumber > 20)
					isParcelShop = true;
				if (Convert.IsDBNull(orderData["VPrHmotnost"]) || IsEveningParcel)
				{
					var dialog = new MultiParcelDialog();
					dialog.Text = "Uveďte hmotnost zásilky";
					dialog.ShowDialog();
					while (!double.TryParse(dialog.input, out _))
					{
						dialog.ShowDialog();
					}
					Weight = double.Parse(dialog.input);
				}
				else
					Weight = Double.Round((double)orderData["VPrHmotnost"], 3);
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
			}
			catch (Exception e)
			{
				throw new OrderParameterNotFoundException((string)orderData["Cislo"], e.Message);
			}
			VariableSymbol = (string)orderData["VarSym"];
			if (IsEveningParcel)
			{
				IsCashOnDelivery = false;
			}
		}
		public abstract (byte[], string) GetLabel();
	}

	public class CzechPostParcel : Parcel
	{
		public string ParcelPrefix;
		public string TimeStamp;
		public bool isRr = false;
		public int idForm = AdminSettings.CzechPost.IdForm;
		public string idCustomer = AdminSettings.CzechPost.IdCustomer;
		public string idContract = AdminSettings.CzechPost.IdContract;
		public int idLocation = int.Parse(AdminSettings.CzechPost.IdLocation);
		public string idExtTransaction = "1";
		public string PostingOfficeZipCode = AdminSettings.CzechPost.PodaciPostaPSC;
		public List<string> services = new List<string>();

		public CzechPostParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "Česká pošta";
			ParcelPrefix = GetCzechPostParcelPrefix(CourierNumber);
			if (ParcelPrefix == "RR")
			{
				isRr = true;
				idForm = AdminSettings.CzechPost.IdFormRr;
			}
			TimeStamp = TransmissionDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz");
			services.Add(AdminSettings.CzechPost.ServicePrimary);
			if (IsMultiParcel)
				services.Add(AdminSettings.CzechPost.ServiceVk);
			if (IsCashOnDelivery)
				services.Add(AdminSettings.CzechPost.ServiceDobirka);
			if (isRr)
				services.Add(AdminSettings.CzechPost.ServiceRr);
			if (Weight > 26)
				services.Add("L");
			else
				services.Add("M");
		}

		public override (byte[], string) GetLabel()
		{
			return CzechPostApi.GetParcelLabel(this);
		}
	}
	public class DpdParcel : Parcel
	{
		public string ParcelShopId;
		public string ReferenceNumber;

		public DpdParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "DPD";
			if (isParcelShop)
			{
				ParcelShopId = new string(this.recipient.CountryIso + Regex.Replace((string)orderData["Ulice2"], "[^0-9]", ""));
			}
			ReferenceNumber = orderData["Cislo"] + "t" + TransmissionDate.ToString("HHmm");
		}
		public override (byte[], string) GetLabel()
		{
			return DpdApiNew.GetParcelLabel(this); // TESTING
		}
	}
	public class ZasilkovnaParcel : Parcel
	{
		public uint AdressId;
		public ZasilkovnaParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "Zásilkovna";
			// 106 kod pro Zasilkovna domu pro CZ
			AdressId = (CourierNumber == 26) ? 106 : uint.Parse((string)orderData["Ulice2"]);
		}
		public override (byte[], string) GetLabel()
		{
			return ZasilkovnaApi.GetParcelLabel(this);
		}
	}
	public class GlsParcel : Parcel
	{
		public string ParcelShopId;

		public GlsParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "GLS";
			if (isParcelShop)
				ParcelShopId = (string)orderData["Ulice2"];
		}
		public override (byte[], string) GetLabel()
		{
			return GlsApi.GetParcelLabel(this);
		}
	}
	public class PplParcel : Parcel
	{
		public string ReferenceNumber;

		public PplParcel(Dictionary<string, object> orderData, ParcelPreferences preferences) : base(orderData, preferences)
		{
			CourierName = "PPL";
			// ParcelShopId, bude treba?
	
		}

		public override (byte[], string) GetLabel()
		{
			return PplApi.GetParcelLabel(this);
		}
	}
}