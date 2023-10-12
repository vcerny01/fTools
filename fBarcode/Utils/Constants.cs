using System;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace fBarcode.Utils
{
	public static class Constants
	{
		// Path to the admin settings of this app is set always in the home directory of the user
		public static string AdminSettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "fBarcodeSettings.csv");

		// Default path for the Courier Label to be stored when user selects the PDF option
		public static string DefaultPdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CourierLabel.pdf");

		// Path to the config dotfile
		public static string DotfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".fBarcode.config");

		// Default name for the warehouseDatabaseFile
		public const string WarehouseDatabaseFileName = "warehouseDB.sqlite";

		// Tables used in WarehouseDatabase
		public struct WarehouseTables
		{
			public static string WorkerTable = "Workers";
			public static string JobTable = "Jobs";
			public static string ActivityTable = "Activities" + DateTime.Now.Year;
			public static string ParcelTable = "Parcels" + DateTime.Now.Year;
        }

		// Time spans for working with Warehouse data
        public enum DateSpan
        {
			Day,
            Week,
            Month,
            Yearly
        }

        // Required admin settings
        public static string[] RequiredAdminSettingsKeys =  new string[]
		{
			"Pohoda.databaseName",
			"Pohoda.tableName",
			"CzechPost.javaPath",
			"CzechPost.clientAppPath",
			"CzechPost.pfxPath",
			"CzechPost.pfxPassword",
			"CzechPost.jksPath",
			"CzechPost.jksPassword",
			"CzechPost.serviceSyncApiUrl",
			"CzechPost.podaciPostaPSC",
			"CzechPost.idLocation",
			"CzechPost.servicePrimary",
			"CzechPost.serviceDobirka",
			"CzechPost.serviceRr",
			"CzechPost.serviceVk",
			"CzechPost.idCustomer",
			"CzechPost.idContract",
			"CzechPost.idForm",
			"CzechPost.idFormRr",
			"Dpd.apiUrl",
			"Dpd.username",
			"Dpd.password",
			"Dpd.payerId",
			"Dpd.senderAddressId",
			"Dpd.serviceMain",
			"Dpd.applicationType",
			"Zasilkovna.eshop",
			"Zasilkovna.apiUrl",
			"Zasilkovna.apiPassword",
			"Gls.clientNumber",
			"Gls.apiUrl",
			"Gls.username",
			"Gls.password",
			"printerName",
			"warehouseDatabasePath"
		};

		// The connection string is sensitive; it needs to be set as an environment variable on each machine.
		public static string PohodaConnectionString = Environment.GetEnvironmentVariable("fBarcodeConnectionString", EnvironmentVariableTarget.User);
		
		// Csv config for CsvHelper
		public static CsvConfiguration CsvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

    }
}