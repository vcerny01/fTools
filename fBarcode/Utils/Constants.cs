using System;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using FluentDateTime;
using FluentDate;

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
			public const string Ppl = "_Ppl";
		}

		// Stable IDs for parcel jobs (auto-created when missing)
      // Keeping stable GUIDs prevents breaking historical references if parcel jobs are recreated.
		public struct ParcelJobIds
		{
			public static readonly Guid CzechPost = new Guid("7e9c1c7a-9f6f-4dc1-8b25-6b4b6d9c4a01");
			public static readonly Guid Dpd = new Guid("9f2c5a6d-0d1c-4f0b-9f92-45b8f30f9c02");
			public static readonly Guid Gls = new Guid("d1b8c5f0-2d7a-4e6b-9b2f-3c6c2e8f4b03");
			public static readonly Guid Zasilkovna = new Guid("4c7f8e1a-5b2d-4d6a-9a9d-7e2c4b8f1c04");
			public static readonly Guid Ppl = new Guid("e3a6b9c2-1d4f-4f8b-9c3d-2a7b6e4c5d05");
		}

		// Name for the penalization "job"
		public struct PenalizationJob
		{
			public const string Name = "_Penalizace";
			public static Guid Id = new Guid("12345678-90ab-cdef-1234-567890abcdef");
		}

		// Csv config for CsvHelper
		public static CsvConfiguration CsvConfig = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false };

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

		// Calculate start day but for the last day/week/month/year
		public static (DateTime StartDate, DateTime EndDate) CalculateLastStartAndEndDate(Constants.DateSpan dateSpan)
		{
			DateTime currentDate = DateTime.Now;
			DateTime today = DateTime.Today;

			// Calculate the end of the last day
			DateTime lastDayStart = 1.Days().Ago().Date;
			DateTime lastDayEnd = today.Date;

			// Calculate the end of the last week
			var lastWeekStart = 1.Weeks().Ago().Previous(DayOfWeek.Sunday);
			var lastWeekEnd = 1.Weeks().Ago().Next(DayOfWeek.Sunday);

			// Calculate the end of the last month
			
			var yr = 1.Months().Ago().Year;
			var mnth = 1.Months().Ago().Month;
			DateTime lastMonthStart = new DateTime(yr, mnth, 1);
			DateTime lastMonthEnd = new DateTime(lastMonthStart.Year, lastMonthStart.Month, DateTime.DaysInMonth(lastMonthStart.Year, lastMonthStart.Month));

			// Calculate the end of the last year
			int year = DateTime.Now.PreviousYear().Year;
			DateTime lastYearStart = new DateTime(year, 1, 1);
			DateTime lastYearEnd = new DateTime(year, 12, 31);

			return dateSpan switch
			{
				Constants.DateSpan.Day => (lastDayStart, lastDayEnd),
				Constants.DateSpan.Week => (lastWeekStart, lastWeekEnd),
				Constants.DateSpan.Month => (lastMonthStart, lastMonthEnd),
				Constants.DateSpan.Year => (lastYearStart, lastYearEnd),
				_ => (currentDate.Date, currentDate.Date),
			};
		}


	}
}