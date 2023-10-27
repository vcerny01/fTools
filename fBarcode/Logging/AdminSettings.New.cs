using System;
using System.Collections.Generic;
using System.Reflection;
using fBarcode.Utils;


namespace fBarcode.Logging.New
{
	public static class AdminSettings
	{
        public static class Pohoda
        {
            public static string ConnectionString {get; private set;}
            public static string DatabaseName { get; private set; }
            public static string TableName { get; private set; }
        }
        public static class CzechPost
        {
            public static string JavaPath { get; private set; }
            public static string ClientAppPath { get; private set; }
            public static string PfxPath { get; private set; }
            public static string PfxPassword { get; private set; }
            public static string JksPath { get; private set; }
            public static string JksPassword { get; private set; }
            public static string ServiceSyncApiUrl { get; private set; }
            public static string PodaciPostaPSC { get; private set; }
            public static string IdLocation { get; private set; }
            public static string ServicePrimary { get; private set; }
            public static string ServiceDobirka { get; private set; }
            public static string ServiceRr { get; private set; }
            public static string ServiceVk { get; private set; }
            public static string IdCustomer { get; private set; }
            public static string IdContract { get; private set; }
            public static string IdForm { get; private set; }
            public static string IdFormRr { get; private set; }
        }
        public static class Dpd
        {
            public static string ApiUrl { get; private set; }
            public static string Username { get; private set; }
            public static string Password { get; private set; }
            public static string PayerId { get; private set; }
            public static string SenderAddressId { get; private set; }
            public static string ServiceMain { get; private set; }
            public static string ApplicationType { get; private set; }
        }
        public static class Zasilkovna
        {
            public static string Eshop { get; private set; }
            public static string ApiUrl { get; private set; }
            public static string ApiPassword { get; private set; }
        }
        public static class Gls
        {
            public static string ClientNumber { get; private set; }
            public static string ApiUrl { get; private set; }
            public static string Username { get; private set; }
            public static string Password { get; private set; }
        }
        public static string PrinterName { get; private set; }

		static AdminSettings()
		{
			Load();
		}
		public static void Load()
		{
            if (Parse(WarehouseService.GetAdminSettings()) == false)
                GetBetterSettings();
		}
		public static void Set()
		{
            var settings = CsvService.Import.LoadSettings();
            if (Parse(settings) == false)
                GetBetterSettings();
            else
                WarehouseService.SetAdminSettings(settings);
		}
		private static bool Parse(Dictionary<string, string> rawSettings)
		{
            Type adminSettingsType = typeof(AdminSettings);
            foreach (Type subClassType in adminSettingsType.GetNestedTypes())
            {
                FieldInfo[] fields = subClassType.GetFields(BindingFlags.Public | BindingFlags.Static);
                foreach (FieldInfo field in fields)
                {
                    string key = $"{subClassType.Name}.{field.Name}";
                    if (rawSettings.ContainsKey(key))
                    {
                        field.SetValue(null, rawSettings[key]);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static void GetBetterSettings()
        {
            DialogService.ShowMessage("Import nastavení" ,"Aplikace postrádá nastavení nebo jsou ve vadném formátu, je třeba je importovat.");
            Set();
        }
	}
}