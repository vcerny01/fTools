using System;
using fBarcode.Logging;
using fBarcode.Utils;
using CsvHelper;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using fBarcode.Logging.Models;
using System.Linq;

namespace fBarcode.Utils
{
	public static class CsvService
	{
		public static class Import
		{
			public static Worker[] LoadWorkers()
			{
				try
				{
					using (var reader = new StreamReader(GetImportPath("zaměstanců")))
					{
						using (var csv = new CsvReader(reader, Constants.CsvConfig))
						{
							csv.Context.RegisterClassMap<WorkerMap>(); 
							var workers = csv.GetRecords<Worker>().ToArray();
							return workers;
						}
					}
				}
				catch(Exception e) {
					DialogService.ShowError("CSV se nepovedlo načíst", e.Message);
					return null;
				}
			}
			public static Job[] LoadJobs()
			{
				var jobs = new List<Job>();
				return jobs.ToArray();
			}
			public static FinishedParcel[] LoadParcels()
			{
				var parcels = new List<FinishedParcel>();
				return parcels.ToArray();
			}
			public static Activity[] LoadActivities()
			{
				var activities = new List<Activity>();
				return activities.ToArray();
			}
			public static Dictionary<string, string> LoadSettings()
			{
				using (var reader = new StreamReader(GetImportPath("nastavení")))
        		using (var csv = new CsvReader(reader, Constants.CsvConfig))
        		{
            		var records = csv.GetRecords<string[]>();
            		return records.ToDictionary(record => record[0], record => record[1]);
        		}
			}
		}
		public static class Export
		{
			public static void WriteWorkers(Worker[] workers)
			{
				// var rawWorkers = new List<string>();
				// foreach (Worker worker in workers)
				// {
				// 	var item = new string[] {worker.Id.ToString(), ConvertDateTimeToUnixSeconds(worker.TimeStampCreation).ToString(), worker.Name};
				// 	rawWorkers.Add(string.Join(",", item));
				// }
				// File.WriteAllLines(GetExportPath("zaměstnanců"), rawWorkers.ToArray());
				using (var writer = new StreamWriter(GetExportPath("zaměstnanců")))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.WriteRecords(workers);
					}
				}


			}
			public static void WriteJobs(Job[] jobs)
			{
				using (var writer = new StreamWriter(GetExportPath("prací")))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.WriteRecords(jobs);
					}
				}
			}
			public static void WriteParcels(Constants.DateSpan dateSpan)
			{
				// TO DO
			}
			public static void WriteActivities(Constants.DateSpan dateSpan)
			{
				// TO DO
			}
			public static void WriteReport(Constants.DateSpan dateSpan)
			{
				// TO DO
			}
		}
		private static string GetImportPath(string type = "")
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				openFileDialog.Title = $"Zvolte CSV soubor pro import {type}";
				openFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
				while(true)
				{
					DialogResult result = openFileDialog.ShowDialog();
					if (result == DialogResult.OK)
					{
						return openFileDialog.FileName;
					}
				}
			}
		}
		private static string GetExportPath(string type = "")
		{
			using (var saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				saveFileDialog.Title = $"Zvolte lokaci CSV pro export {type}";
				saveFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
				while(true)
				{
					DialogResult result = saveFileDialog.ShowDialog();
					if (result == DialogResult.OK)
					{
						return saveFileDialog.FileName;
					}
				}
			}
		}
		private static long ConvertDateTimeToUnixSeconds(DateTime dateTime)
		{
			DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			TimeSpan timeSinceEpoch = dateTime.ToUniversalTime() - unixEpoch;
			return (long)timeSinceEpoch.TotalSeconds;
		}
	}
}

