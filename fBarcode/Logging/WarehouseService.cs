using System;
using System.IO;
using System.Data.SQLite;
using fBarcode.Fichema;
using fBarcode.Utils;
using System.Collections.Generic;

namespace fBarcode.Logging
{
	public static class WarehouseService
	{
		private static string dbPath;
		private static string dbPasswordHash;
		private static string dbConnectionString;
		private static string passwordHash = "";

		static WarehouseService()
		{
			try
			{
				string[] dotfileContent = File.ReadAllLines(Constants.DotfilePath);
				dbPath = dotfileContent[0];
				dbPasswordHash = dotfileContent[1];
				if (!Path.IsPathRooted(dbPath))
					throw new Exception();
			} catch (Exception)
			{
				File.Delete(Constants.DotfilePath);
				SetupDatabase();
			}
			string dbPassword = GetDatabasePassword(dbPasswordHash);
            dbConnectionString = $"Data Source={dbPath};Version=3;Password={dbPassword};";
			try
			{
				var connection = new SQLiteConnection(dbConnectionString);
				connection.Open();
				connection.Close();
			} catch (Exception e)
			{
				DialogService.ShowError("Připojení ke skladové databázi selhalo", $"Připojení k databázi skladu selhalo. Restartujte aplikaci nebo kontaktujte technickou podporu. Více podrobností: \n{e.Message}");
				System.Windows.Forms.Application.Exit();
			}
        }

        public static List<Worker> GetWorkers()
		{

		}
		public static void SetWorkers(List<Worker> workers)
		{

		}
		public static List<Job> GetJobs()
		{

		}
		public static void SetJobs(List<Job> jobs)
		{

		}
		public static void LogParcel(Parcel parcel, Worker worker)
		{

		}
		public static void LogActivity(Job job, int value)
		{

		}
		private static void SetupDatabase()
		{
			// GetDatabasePathDialog
			// GetDatabasePasswordDialog
			// Create database
			// Prompt to load CSV configs
		}
		private static string GetDatabasePassword(string hash)
		{
			// GetDatabasePasswordDialog
		}
	}
}