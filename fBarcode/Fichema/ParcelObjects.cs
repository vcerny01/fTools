﻿using System;
using fBarcode.UI.Dialogs;
using System.Collections.Generic;
using fBarcode.Exceptions;
using fBarcode.Utils;
using System.IO;

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
                if (!isParcelShop)
                {
                    string fullStreet = (string)orderData["Ulice2"];
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
                PhoneNumber = (string)orderData["Tel2"];
                PhoneNumber = PhoneNumber.Replace(" ", "");
                if (PhoneNumber == "")
                {
                    PhoneNumber = (string)orderData["Tel"];
                    PhoneNumber = PhoneNumber.Replace(" ", "");
                    if (PhoneNumber == "")
                    {
                        throw new OrderParameterNotFoundException(orderNumber, "U objednávky chybí telefonní číslo.");
                    }
                }
                PhoneNumber = PhoneNumber.Replace("+420", "");
                EmailAdress = (string)orderData["Email2"];
                CountryIso = GetCountryIso(orderData["RefZeme"].ToString());
                if (orderData["Firma2"] != null)
                {
                    isCompany = true;
                    CompanyName = (string)orderData["Firma2"];
                }
            }
            protected string GetCountryIso(string countryNumber)
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
        protected int GetMultiParcelCount()
        {
            MultiParcelDialog dialog = new();
            dialog.Text = "Počet kusů ve VK";
            while (!int.TryParse(dialog.input, out _) || int.Parse(dialog.input) > 5)
            {
                dialog.ShowDialog();
            }
            return int.Parse(dialog.input);
        }
        protected string GetCzechPostParcelPrefix(int courierNumber)
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
        protected bool RequiresCashOnDelivery(int formOfPaymentId)
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

