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
           // Map parcel job names to stable GUIDs so parcel job IDs stay consistent without requiring import.
			private static Guid GetParcelJobIdByName(string name)
			{
				return name switch
				{
					Constants.ParcelJobNames.CzechPost => Constants.ParcelJobIds.CzechPost,
					Constants.ParcelJobNames.Dpd => Constants.ParcelJobIds.Dpd,
					Constants.ParcelJobNames.Gls => Constants.ParcelJobIds.Gls,
					Constants.ParcelJobNames.Zasilkovna => Constants.ParcelJobIds.Zasilkovna,
					Constants.ParcelJobNames.Ppl => Constants.ParcelJobIds.Ppl,
					_ => Guid.NewGuid(),
				};
			}
			public static Worker[] LoadWorkers()
			{
				var workers = new List<Worker>();
				try
				{
					string path = GetImportPath("zaměstanců");
					if (path == null) return null;
					string[] rawRecord = File.ReadAllLines(path);
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

          // Import jobs; parcel jobs are optional and their durations are ignored (computed elsewhere).
			public static Job[] LoadJobs()
			{
				var jobs = new List<Job>();
				try
				{
					string path = GetImportPath("typů činností");
					if (path == null) return null;
					string[] rawRecord = File.ReadAllLines(path);
					{
						var parcelJobNames = new HashSet<string>
						{
							Constants.ParcelJobNames.CzechPost,
							Constants.ParcelJobNames.Dpd,
							Constants.ParcelJobNames.Gls,
							Constants.ParcelJobNames.Zasilkovna,
							Constants.ParcelJobNames.Ppl
						};

						foreach (string line in rawRecord)
						{
							string[] record = line.Replace("\"", "").Split(',');
							string name = record.Length > 0 ? record[0] : null;
							bool isParcelJob = name != null && parcelJobNames.Contains(name);
							if (record.Length == 4)
							{
								Guid id = Guid.Parse(record[1]);
								int duration = isParcelJob ? 0 : int.Parse(record[2]);
								jobs.Add(new Job(name, id, duration, ConvertUnixSecondsToDateTime(long.Parse(record[3]))));
							}
							else if (record.Length == 2)
							{
								int duration = isParcelJob ? 0 : int.Parse(record[1]);
								if (isParcelJob)
								{
									Guid id = GetParcelJobIdByName(name);
									jobs.Add(new Job(name, id, duration, DateTime.MinValue));
								}
								else
								{
									jobs.Add(new Job(name, duration));
								}
							}
							else if (record.Length == 1 && isParcelJob)
							{
								Guid id = GetParcelJobIdByName(name);
								jobs.Add(new Job(name, id, 0, DateTime.MinValue));
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
					string path = GetImportPath("vytvořených zásilek");
					if (path == null) return null;
					string[] rawRecord = File.ReadAllLines(path);
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
					string path = GetImportPath("proběhlých činností");
					if (path == null) return null;
					string[] rawRecord = File.ReadAllLines(path);
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
				string path = GetImportPath("konfigurace");
				if (path == null) return null;
				var settings = new Dictionary<string, string>();
				using (var reader = new StreamReader(path))
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
				string path = GetExportPath("zaměstnanců");
				if (path == null) return;
				using (var writer = new StreamWriter(path))
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
				string path = GetExportPath("prací");
				if (path == null) return;
				using (var writer = new StreamWriter(path))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.Context.RegisterClassMap<JobMap>();
						csv.WriteRecords(jobs);
					}
				}
			}
			public static bool WriteFinishedParcels(FinishedParcel[] parcels)
			{
				string path = GetExportPath("dokončených zásilek");
				if (path == null) return false;
				using (var writer = new StreamWriter(path))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.Context.RegisterClassMap<FinishedParcelMap>();
						csv.WriteRecords(parcels);
					}
				}
				return true;
			}
			public static bool WriteActivities(Activity[] activities)
			{
				string path = GetExportPath("vykonaných činností");
				if (path == null) return false;
				using (var writer = new StreamWriter(path))
				{
					using (var csv = new CsvWriter(writer, Constants.CsvConfig))
					{
						csv.Context.RegisterClassMap<ActivityMap>();
						csv.WriteRecords(activities);
					}
				}
				return true;
			}
			public static void WriteReport(Constants.DateSpan dateSpan)
			{
				string path = GetExportPath("výkazu");
				if (path == null) return;
				File.WriteAllText(path, WarehouseManager.GenerateReportText(dateSpan));
			}
		}
		private static string GetImportPath(string type = "")
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				openFileDialog.Title = $"Zvolte CSV soubor pro import {type}";
				openFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
				DialogResult result = openFileDialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					return openFileDialog.FileName;
				}
				return null;
			}
		}
		private static string GetExportPath(string type = "")
		{
			using (var saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				saveFileDialog.Title = $"Zvolte lokaci CSV pro export {type}";
				saveFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
				DialogResult result = saveFileDialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					return saveFileDialog.FileName;
				}
				return null;
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

