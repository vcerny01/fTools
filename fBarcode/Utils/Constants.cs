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
		public const string WarehouseDatabaseFileName = "warehouseDB.sdf";

		// Tables used in WarehouseDatabase
		public struct WarehouseTables
		{
			public const string WorkerTable = "Workers";
			public const string JobTable = "Jobs";
			public const string ActivityTable = "Activities";
			public const string ParcelTable = "Parcels";
			public const string AdminSettingsTable = "AdminSettings";
        }

		// Time spans for working with Warehouse data
        public enum DateSpan
        {
			Day,
            Week,
            Month,
            Year,
        }
		
		// Names for parcels
		public struct ParcelJobNames
		{
			public const string CzechPost = "_CzechPost";
			public const string Dpd = "_Dpd";
			public const string Gls = "_Gls";
			public const string Zasilkovna = "_Zasilkovna";
		}

		// Name for the penalization "job"
		public struct PenalizationJob
		{
			public const string Name = "_Penalizace";
			public static Guid Id = new Guid("12345678-90ab-cdef-1234-567890abcdef");
		}

		// Csv config for CsvHelper
		public static CsvConfiguration CsvConfig = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false};

		public const string UndefinedString = "nedefin.";

		// Method to calculate a start date from DateSpan enum
		public static DateTime CalculateStartDate(Constants.DateSpan dateSpan)
		{
			DateTime currentDate = DateTime.Now;
			return dateSpan switch
			{
				DateSpan.Day => DateTime.Now.Date,
				DateSpan.Week => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday),
				DateSpan.Month => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1),
				DateSpan.Year => new DateTime(DateTime.Today.Year, 1, 1),
				_ => currentDate,
			};
		}
    }
}