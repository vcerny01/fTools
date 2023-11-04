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
				var workers = new List<Worker>();
				try
				{
					string[] rawRecord = File.ReadAllLines(GetImportPath("zaměstanců"));
					{
						foreach (string line in rawRecord)
						{
							string[] record = line.Replace("\"", "").Split(',');
							if (record.Length == 1 || record.Length == 3)
							{
								if (record.Length == 1)
									workers.Add(new Worker(record[0]));
								if (record.Length == 3)
									workers.Add(new Worker(record[0], Guid.Parse(record[1]), ConvertUnixSecondsToDateTime(long.Parse(record[2]))));
							}
						}
					}
				}
				catch (Exception e)
				{
					DialogService.ShowError("CSV se nepovedlo načíst", e.Message);
					return null;
				}
				AlertImportedObjects(workers.Count);
				return workers.ToArray();
			}

			public static Job[] LoadJobs()
			{
				var jobs = new List<Job>();
				try
				{
					string[] rawRecord = File.ReadAllLines(GetImportPath("typů činností"));
					{
						foreach (string line in rawRecord)
						{
							string[] record = line.Replace("\"", "").Split(',');
							if (record.Length == 2 || record.Length == 4)
							{
								if (record.Length == 2)
									jobs.Add(new Job(record[0], int.Parse(record[1])));
								if (record.Length == 4)
									jobs.Add(new Job(record[0], Guid.Parse(record[1]), int.Parse(record[2]), ConvertUnixSecondsToDateTime(long.Parse(record[3]))));
							}
						}
					}
				}
				catch (Exception e)
				{
					DialogService.ShowError("CSV se nepovedlo načíst", e.Message);
					return null;
				}
				AlertImportedObjects(jobs.Count);
				return jobs.ToArray();
			}
			public static FinishedParcel[] LoadParcels()
			{
				var parcels = new List<FinishedParcel>();
				try
				{
					string[] rawRecord = File.ReadAllLines(GetImportPath("vytvořených zásilek"));
					{
						foreach (string line in rawRecord)
						{
							string[] record = line.Replace("\"", "").Split(',');
							if (record.Length == 5)
							{
								parcels.Add(new FinishedParcel(Guid.Parse(record[0]), ConvertUnixSecondsToDateTime(long.Parse(record[4])), Guid.Parse(record[1]), record[2], record[3]));
							}
						}
					}
				}
				catch (Exception e)
				{
					DialogService.ShowError("CSV se nepovedlo načíst", e.Message);
					return null;
				}
				AlertImportedObjects(parcels.Count);
				return parcels.ToArray();
			}
			public static Activity[] LoadActivities()
			{
				var activities = new List<Activity>();
				try
				{
					string[] rawRecord = File.ReadAllLines(GetImportPath("proběhlých činností"));
					{
						foreach (string line in rawRecord)
						{
							string[] record = line.Replace("\"", "").Split(',');
							if (record.Length == 7 || record.Length == 8)
							{
								activities.Add(new Activity(Guid.Parse(record[0]), Guid.Parse(record[1]), Guid.Parse(record[2]), int.Parse(record[3]), int.Parse(record[4]), decimal.Parse(record[5]), ConvertUnixSecondsToDateTime(long.Parse(record[6])), string.IsNullOrWhiteSpace(record[7]) ? null : record[7]));
							}
						}
					}
				}
				catch (Exception e)
				{
					DialogService.ShowError("CSV se nepovedlo načíst", e.Message);
					return null;
				}
				AlertImportedObjects(activities.Count);
				return activities.ToArray();
			}
			public static Dictionary<string, string> LoadSettings()
			{
				var settings = new Dictionary<string, string>();
				using (var reader = new StreamReader(GetImportPath("konfigurace")))
				using (var csv = new CsvReader(reader, Constants.CsvConfig))
				{
					while (csv.Read())
					{
						var key = csv.GetField(0);
						var value = csv.GetField(1);
						settings[key] = value;
					}
				}
				return settings;
			}
		}
		public static class Export
		{
			public static void WriteWorkers(Worker[] workers)
			{
				using (var writer = new StreamWriter(GetExportPath("zaměstnanců")))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.Context.RegisterClassMap<WorkerMap>();
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
						csv.Context.RegisterClassMap<JobMap>();
						csv.WriteRecords(jobs);
					}
				}
			}
			public static void WriteFinishedParcels(FinishedParcel[] parcels)
			{
				using (var writer = new StreamWriter(GetExportPath("dokončených zásilek")))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.Context.RegisterClassMap<FinishedParcelMap>();
						csv.WriteRecords(parcels);
					}
				}
			}
			public static void WriteActivities(Activity[] activities)
			{
				using (var writer = new StreamWriter(GetExportPath("vykonaných činností")))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.Context.RegisterClassMap<ActivityMap>();
						csv.WriteRecords(activities);
					}
				}
			}
			public static void WriteReport(Constants.DateSpan dateSpan)
			{
				File.WriteAllText(GetExportPath("výkazu"), WarehouseManager.GenerateReportText(dateSpan));
			}
		}
		private static string GetImportPath(string type = "")
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				openFileDialog.Title = $"Zvolte CSV soubor pro import {type}";
				openFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
				while (true)
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
				while (true)
				{
					DialogResult result = saveFileDialog.ShowDialog();
					if (result == DialogResult.OK)
					{
						return saveFileDialog.FileName;
					}
				}
			}
		}
		private static void AlertImportedObjects(int count)
		{
			DialogService.ShowMessage("Import dokončen", $"Počet úspěšně naimportovaných objektů: {count}");
		}
		public static DateTime ConvertUnixSecondsToDateTime(long unixSeconds)
		{
			DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return unixEpoch.AddSeconds(unixSeconds);
		}
	}
}

