using System;
using fBarcode.UI.Dialogs;
using System.Collections.Generic;
using fBarcode.Exceptions;
using fBarcode.Utils;


namespace fBarcode.Fichema
{
    public class ParcelPreferences
    {
        public bool ForceMultiParcel;
        public bool EveningParcel;
        public bool SaveCourierLabel;
        public bool UserConfirmParcel;

        public ParcelPreferences(bool multiParcel, bool eveningParcel, bool saveBarcode, bool confirmParcel)
        {
            ForceMultiParcel = multiParcel;
            EveningParcel = eveningParcel;
            SaveCourierLabel = saveBarcode;
            UserConfirmParcel = confirmParcel;
        }
    }
    public abstract partial class Parcel
    {
        public class RecipientInfo
        {
            public string FirstName;
            public string LastName;
            public string PostalCode;
            public string Street;
            public string HouseNumber;
            public string City;
            public string PhoneNumber;
            public string EmailAdress;
            public string CountryIso;
            public bool isCompany = false;
            public string CompanyName;

			public RecipientInfo(Dictionary<string, object> orderData, bool isParcelShop)
			{
				string orderNumber = (string)orderData["Cislo"];
				string fullName = (string)orderData["Jmeno2"];
				int CourierNumber = (int)orderData["RefDopravci"];
				string[] nameParts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				if (nameParts.Length >= 2)
				{
					FirstName = nameParts[0];
					LastName = string.Join(" ", nameParts, 1, nameParts.Length - 1);
				}
				else
				{
					FirstName = "";
					LastName = string.Join(" ", nameParts);
				}
				PostalCode = (string)orderData["PSC2"];
				PostalCode = PostalCode.Replace(" ", "");
				// Only parse street if CourierNumber isn't 23,24,25 because these are parcel shops
				string czechPostPrefix = GetCzechPostParcelPrefix(CourierNumber);
				switch (GetCzechPostParcelPrefix(CourierNumber))
				{
					case "NB":
						Street = "BALÍKOVNA";
						isParcelShop = true;
						break;
					case "NP":
						Street = "Na poštu";
						isParcelShop = true;
						break;
				}
                 if (!isParcelShop || CourierNumber == 25)
                {
					string fullStreet;
					if (CourierNumber == 25) // necessary exception for DPD parcel shop (always requires receiverStreet)
						fullStreet = (string)orderData["Ulice"];
					else
						fullStreet = (string)orderData["Ulice2"];
                    string[] streetParts = fullStreet.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (streetParts.Length >= 2)
                    {
                        int lastPartIndex = streetParts.Length - 1;
                        Street = string.Join(" ", streetParts, 0, lastPartIndex);
                        HouseNumber = streetParts[lastPartIndex];
                    }
                    else
                    {
                        throw new OrderParameterNotFoundException(orderNumber, "Objednávka není na parcel shop a ulice chybí nebo je ve špatném formátu.");
                    }
                }
                City = (string)orderData["Obec2"];
                City = City.Replace(".", "");
                PhoneNumber = (orderData["Tel2"] as string).Replace(" ", "") ?? "";
                if (PhoneNumber == "")
                {
                    PhoneNumber = (orderData["Tel"] as string).Replace(" ", "") ?? "";
                    if (PhoneNumber == "")
                    {
                        throw new OrderParameterNotFoundException(orderNumber, "U objednávky chybí telefonní číslo.");
                    }
                }
                PhoneNumber = PhoneNumber.Replace("+420", "");
                EmailAdress = orderData["Email2"] as string ?? "";
                CountryIso = GetCountryIso(orderData["RefZeme"].ToString());
                if (!Convert.IsDBNull(orderData["Firma2"]))
                {
                    isCompany = true;
                    CompanyName = orderData["Firma2"] as string;
                }
            }
            protected static string GetCountryIso(string countryNumber)
            {
                switch (countryNumber)
                {
                    case "40":
                        return "CZ";
                    case "187":
                        return "SK";
                    case "146":
                        return "DE";
                    case "170":
                        return "AT";
                    case "168":
                        return "PL";
                    case "207":
                        return "ES";
                    case "83":
                        return "IT";
                    case "153":
                        return "NL";
                    default:
                        DialogService.ShowMessage("Změna ISO kódu", "ISO kód Země (RefZeme) pru tuto objednávku chybí nebo nebyl nalezen. Byl tedy stanoven na CZ");
                        return "CZ";
                }
            }
        }
        protected static int GetMultiParcelCount()
        {
            MultiParcelDialog dialog = new();
            while (!int.TryParse(dialog.input, out _) || int.Parse(dialog.input) > 5)
            {
                dialog.ShowDialog();
            }
            return int.Parse(dialog.input);
        }
        protected static string GetCzechPostParcelPrefix(int courierNumber)
        {
            switch (courierNumber)
            {
                case 10:
                    return "DR";
                case 14:
                case 15:
                    return "NP";
                case 16:
                case 18:
                    return "NB";
                case 19:
                case 22:
                    return "RR";
                default:
                    return null;
            }
        }
        protected static bool RequiresCashOnDelivery(int formOfPaymentId)
        {
            switch (formOfPaymentId)
            {
                case 18:
                case 4:
                    return true;
                default:
                    return false;
            }
        }
    }
}

