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

		public static string DefaultPdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CourierLabel.pdf");

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
			"CzechPost.locationNumber",
			"CzechPost.servicePrimary",
			"CzechPost.serviceDobirka",
			"CzechPost.serviceRr",
			"CzechPost.serviceVk",
			"CzechPost.idCustomer",
			"CzechPost.idContract",
			"CzechPost.idForm",
			"CzechPost.idFormRr",
			"CzechPost.labelShiftHorizontal",
			"CzechPost.labelShiftVertical",
			"CzechPost.labelPosition",
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
			"printerName"
		};

		// The connection string is sensitive; it needs to be set as an environment variable on each machine.
		public static string PohodaConnectionString = Environment.GetEnvironmentVariable("fBarcodeConnectionString", EnvironmentVariableTarget.User);
		
		// Csv config for CsvHelper
		public static CsvConfiguration CsvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
	}
}