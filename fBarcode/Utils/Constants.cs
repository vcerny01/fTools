using System;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace fBarcode.Utils
{
	public static class Constants
	{
		// Path to the admin settings of this app is set always in the home directory of the user
		public static string adminSettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "fBarcodeSettings.csv");

		// Required admin settings
		public static string[] requiredAdminSettingsKeys =  new string[]
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
			"CzechPost.locationNumber",
			"CzechPost.servicePrimary",
			"CzechPost.serviceDobirka",
			"CzechPost.serviceRr",
			"CzechPost.serviceVk",
			"CzechPost.idCustomer",
			"CzechPost.idForm",
			"CzechPost.labelShiftHorizontal",
			"CzechPost.labelShiftVertical",
			"CzechPost.labelPosition",
			"Dpd.apiUrl",
			"Dpd.userName",
			"Dpd.Password",
			"Dpd.PayerId",
			"Dpd.SenderAddressId",
			"Dpd.serviceMain",
			"Dpd.ApplicationType",
			"Zasilkovna.eshop",
			"Zasilkovna.apiUrl",
			"Zasilkovna.apiPassword",
			"Gls.clientNumber",
			"Gls.apiUrl",
			"Gls.userName",
			"Gls.password",
			"printerName"
		};

		// The connection string is sensitive; it needs to be set as an environment variable on each machine.
		public static string parcelDatabaseConnectionString = Environment.GetEnvironmentVariable("fBarcodeConnectionString");
		
		// Csv config for CsvHelper
		public static CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
	}
}