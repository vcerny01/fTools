using System;
using System.Collections.Generic;
using fBarcode.Fichema;
using fBarcode.Logging;
using WService = fBarcode.Logging.WarehouseService;
using fBarcode.Logging.Models;
using System.Linq;
using fBarcode.Utils;
using ParcelJobNames = fBarcode.Utils.Constants.ParcelJobNames;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace fBarcode.Logging
{
	public static class WarehouseManager
	{
		private static List<Activity> YearActivities;
		private static List<Guid> AllActivityIds;
		private static List<FinishedParcel> YearParcels;
		private static List<Guid> AllParcelIds;
		public static List<Worker> Workers { get; private set; }
		public static List<Job> Jobs { get; private set; }
		private static Dictionary<Worker, List<Activity>> WorkerActivities;
		public static Worker ActiveWorker { get; private set; }
		public static Job ActiveJob { get; private set; }
		public static Job PenalizationJob { get; private set; }

		public static class ParcelJobs
		{
			public static Job CzechPostParcel;
			public static Job DpdParcel;
			public static Job GlsParcel;
			public static Job ZasilkovnaParcel;
			public static Job PplParcel;
		}

		static WarehouseManager()
		{
			Setup();
		}
        public static void Setup()
		{
			var createdAt = DateTime.Now;
			PenalizationJob = new Job(Constants.PenalizationJob.Name, Constants.PenalizationJob.Id, -AdminSettings.Misc.PenalizationRateInSeconds, createdAt);
			Workers = WService.GetWorkers();
			Jobs = WService.GetJobs();
			Jobs.Add(PenalizationJob);
			YearActivities = WService.GetPastActivities(DateTime.Now.AddYears(-1));
			YearParcels = WService.GetFinishedParcels(DateTime.Now.AddYears(-1));
			AllActivityIds = WService.GetPastActivities().Select(activity => activity.Id).ToList();
			AllParcelIds = WService.GetFinishedParcels().Select(parcel => parcel.Id).ToList();
			WorkerActivities = GetWorkerActivities(Workers.ToArray(), YearActivities.ToArray());

			EnsureParcelJobs();
			AssignParcelJobs();
		}
		
      // Ensure parcel jobs are present (create if missing) so parcel activities always have target jobs.
		private static void EnsureParcelJobs()
		{
			bool updated = false;
			updated |= EnsureParcelJob(ParcelJobNames.CzechPost, Constants.ParcelJobIds.CzechPost);
			updated |= EnsureParcelJob(ParcelJobNames.Dpd, Constants.ParcelJobIds.Dpd);
			updated |= EnsureParcelJob(ParcelJobNames.Gls, Constants.ParcelJobIds.Gls);
			updated |= EnsureParcelJob(ParcelJobNames.Zasilkovna, Constants.ParcelJobIds.Zasilkovna);
			updated |= EnsureParcelJob(ParcelJobNames.Ppl, Constants.ParcelJobIds.Ppl);

			if (updated)
				WService.SetJobs(Jobs);
		}

       // Create a parcel job with a stable ID only when it doesn't already exist (preserves existing records).
        private static bool EnsureParcelJob(string name, Guid id)
		{
			var existing = Jobs.FirstOrDefault(job => job.Name == name);
			if (existing != null)
				return false;

         Jobs.Add(new Job(name, id, 0, DateTime.Now));
			return true;
		}

      // Cache parcel job instances for quick lookup.
		private static void AssignParcelJobs()
		{
			ParcelJobs.CzechPostParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.CzechPost);
			ParcelJobs.DpdParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.Dpd);
			ParcelJobs.GlsParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.Gls);
			ParcelJobs.ZasilkovnaParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.Zasilkovna);
			ParcelJobs.PplParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.Ppl);
		}
     public static void CheckIntegrity()
		{
			if (Workers.Count == 0)
			{
				var workers = CsvService.Import.LoadWorkers();
				if (workers == null)
					System.Environment.Exit(0);
				SetWorkers(workers);
			}

			// Ignore technical jobs (parcel + penalization) when deciding if user-facing jobs exist.
			if (!GetJobNames().Any())
			{
				var jobs = CsvService.Import.LoadJobs();
				if (jobs == null)
					System.Environment.Exit(0);
				SetJobs(jobs);
			}
		}
		public static void SetWorkers(Worker[] workers)
		{
			Workers = new List<Worker>(workers);
			WService.SetWorkers(Workers);
		}
      // Merge safeguard: if an import omits parcel jobs, keep existing ones (and their GUIDs) to preserve historical links.
		public static void SetJobs(Job[] jobs)
		{
			var merged = new List<Job>(jobs);
			var existing = WService.GetJobs();
			var parcelNames = new HashSet<string>
			{
				Constants.ParcelJobNames.CzechPost,
				Constants.ParcelJobNames.Dpd,
				Constants.ParcelJobNames.Gls,
				Constants.ParcelJobNames.Zasilkovna,
				Constants.ParcelJobNames.Ppl
			};

			foreach (var name in parcelNames)
			{
				if (merged.Any(j => j.Name == name))
					continue;

				var keep = existing.FirstOrDefault(j => j.Name == name);
				if (keep != null)
				{
					merged.Add(keep);
				}
				else
				{
                    var id = name switch
					{
						Constants.ParcelJobNames.CzechPost => Constants.ParcelJobIds.CzechPost,
						Constants.ParcelJobNames.Dpd => Constants.ParcelJobIds.Dpd,
						Constants.ParcelJobNames.Gls => Constants.ParcelJobIds.Gls,
						Constants.ParcelJobNames.Zasilkovna => Constants.ParcelJobIds.Zasilkovna,
						Constants.ParcelJobNames.Ppl => Constants.ParcelJobIds.Ppl,
						_ => Guid.NewGuid()
					};
					merged.Add(new Job(name, id, 0, DateTime.Now));
				}
			}

			Jobs = merged;
			WService.SetJobs(Jobs);
			AssignParcelJobs();
		}
		public static void AddParcel(Parcel parcel)
		{
			var fParcel = new FinishedParcel(ActiveWorker.Id, parcel.OrderNumber, parcel.VariableSymbol);
			WService.LogParcel(fParcel);
			AllParcelIds.Add(fParcel.Id);
			YearParcels.Add(fParcel);
		}
		public static List<Guid> AddFinishedParcels(FinishedParcel[] finishedParcels)
		{
			var rejectedIds = new List<Guid>();
			foreach(FinishedParcel fParcel in finishedParcels)
			{
				if (AllParcelIds.Contains(fParcel.Id))
					rejectedIds.Add(fParcel.Id);
				else
				{
					if (fParcel.TimeStampCreation >= DateTime.Now.AddYears(-1))
					{
						YearParcels.Add(fParcel);
					}
					WService.LogParcel(fParcel);
				}
			}
			return rejectedIds;
		}
		public static void AddActivity(Activity activity)
		{
			WService.LogActivity(activity);
			AllActivityIds.Add(activity.Id);
			YearActivities.Add(activity);
			WorkerActivities[ActiveWorker].Add(activity);
		}
		public static List<Guid> AddActivities(Activity[] activities)
		{
			var rejectedIds = new List<Guid>();
			foreach(Activity activity in activities)
			{
				if (AllActivityIds.Contains(activity.Id))
					rejectedIds.Add(activity.Id);
				else
				{
					if (activity.TimeStampCreation >= DateTime.Now.AddYears(-1))
					{
						YearActivities.Add(activity);
					}
					WService.LogActivity(activity);
				}
			}
			return rejectedIds;
		}
		public static void DeleteItems(Type type, Guid[] ids)
		{
			if (type == typeof(Worker))
				WService.DeleteRecords(ids, Constants.WarehouseTables.WorkerTable);
			else if (type == typeof(Job))
				WService.DeleteRecords(ids, Constants.WarehouseTables.JobTable);
			else if (type == typeof(Activity))
				WService.DeleteRecords(ids, Constants.WarehouseTables.ActivityTable);
			else if (type == typeof(FinishedParcel))
				WService.DeleteRecords(ids, Constants.WarehouseTables.ParcelTable);
			Setup();
		}
		public static List<KeyValuePair<Guid, string>> GetWorkerNames()
		{
			return Workers.Select(worker => new KeyValuePair<Guid, string>(worker.Id, worker.Name)).ToList();
		}
		public static List<KeyValuePair<Guid, string>> GetJobNames()
		{
			var excludedJobNames = new List<string>
			{
				ParcelJobNames.CzechPost,
				ParcelJobNames.Dpd,
				ParcelJobNames.Gls,
				ParcelJobNames.Zasilkovna,
				ParcelJobNames.Ppl,
				PenalizationJob.Name
			};

			return Jobs
				.Where(job => !excludedJobNames.Contains(job.Name))
				.Select(job => new KeyValuePair<Guid, string>(job.Id, $"{job.Name} ({job.DurationInSeconds / 60} min)"))
				.ToList();
		}

		public static void SetActiveWorker(Guid id)
		{
			ActiveWorker = Workers.FirstOrDefault(worker => worker.Id == id);
		}
		public static void SetActiveJob(Guid id)
		{
			ActiveJob = Jobs.FirstOrDefault(job => job.Id == id);
		}
		public static string GenerateOverviewText()
		{
			var sb = new StringBuilder();
			Activity[] activeWorkerActivities = WorkerActivities[ActiveWorker].ToArray();
			var todayDuration = SumActivitiesDuration(activeWorkerActivities, Constants.DateSpan.Day);
			var todayParcelCount = SumParcelsCount(activeWorkerActivities, Constants.DateSpan.Day);
			var monthDuration = SumActivitiesDuration(activeWorkerActivities, Constants.DateSpan.Month);
			var monthParcelCount = SumParcelsCount(activeWorkerActivities, Constants.DateSpan.Month);
			var todayEarning = SumActivitiesEarning(activeWorkerActivities, Constants.DateSpan.Day);
			var monthEarning = SumActivitiesEarning(activeWorkerActivities, Constants.DateSpan.Month);
			//var weekPercentile = CalculateWorkerPercentile(ActiveWorker, WorkerActivities);
			sb.AppendLine($"Za dnešek odpracováno: {todayDuration / 60} min");
			sb.AppendLine($"   Počet balíků: {todayParcelCount}");
			sb.AppendLine($"Celkově za měsíc odpracováno: {monthDuration / 60} min");
			sb.AppendLine($"   Počet balíků: {monthParcelCount}");
			//sb.AppendLine($"   => {todayEarning.ToString($"F{2}")} Kč");
			//sb.AppendLine($"Celkově výdělek za tento měsíc: {monthEarning.ToString($"F{2}")} Kč");
			//sb.AppendLine($"Týdenní percentil výkonnosti: {weekPercentile}%");
			return sb.ToString();
		}
		public static string GenerateLogText()
		{
			Activity[] latestActivites = GetLatestActivities(12);
			var sb = new StringBuilder();
			foreach (Activity a in latestActivites)
			{
				var jobName = GetJobNameById(a.JobId);
				var workerName = GetWorkerNameById(a.WorkerId);
				if (jobName.Length > 15)
					jobName = jobName.Substring(0, 12) + "...";
				if (workerName.Length > 15)
					workerName = workerName.Substring(0, 12) + "...";

				string timeString = $"{a.TimeStampCreation.Hour:D2}:{a.TimeStampCreation.Minute:D2}";
				sb.AppendLine($"{timeString}   {workerName}: {jobName}   {a.Duration / 60} min");
			}
			return sb.ToString();
		}
		public static bool CheckParcelFinished(string orderNumber)
		{
			FinishedParcel parcel = YearParcels.FirstOrDefault(p => p.OrderNumber == orderNumber);
			return parcel != null;
		}

		public static string GenerateReportText(Constants.DateSpan dateSpan)
		{
			var sb = new StringBuilder();
			(DateTime, DateTime) dates = Constants.CalculateLastStartAndEndDate(dateSpan);
			string timeSpanString = dateSpan switch
			{
				Constants.DateSpan.Day => "den", 
				Constants.DateSpan.Week => "týden",
				Constants.DateSpan.Month => "měsíc",
				Constants.DateSpan.Year => "rok",
				_ => null
			};
			string currentDate = DateTime.Now.ToString("dd. MM. yyyy");
			sb.AppendLine($"VÝKAZ za minulý {timeSpanString}");
			sb.AppendLine($"Vyvořen: {currentDate}");
			sb.Append("\n\n");
			sb.AppendLine("Přehled všech vytvořených zásilek:");
			sb.AppendLine("číslo faktury,variabilní symbol");
			foreach(FinishedParcel parcel in YearParcels.Where(p => ((p.TimeStampCreation >= dates.Item1) && (p.TimeStampCreation <= dates.Item2))))
			{
				sb.AppendLine($"{parcel.OrderNumber},{parcel.VarSym}");
			}
			sb.AppendLine("\nPřehled aktivity na činnostech:");
			sb.AppendLine("typ činnosti,počet");
			var jobsActivity = GetJobsActivity(dates);
			foreach (KeyValuePair<Job,int> k in jobsActivity)
			{
				sb.AppendLine($"{k.Key.Name},{k.Value}");
			}
			sb.AppendLine("\nPřehled produktivity zaměstnanců");
			sb.AppendLine("jméno zaměstnance,odpracovaný čas v minutách,celkový výdělek v korunách");
			var workersActivity = GetWorkersActivity(dates);
			foreach (KeyValuePair<Worker, int> k in workersActivity)
			{
				sb.AppendLine($"{k.Key.Name},{k.Value / 60},{SumActivitiesEarning(WorkerActivities[k.Key].ToArray(), dateSpan).ToString($"F{2}")}");
			}
			return sb.ToString();
		}

		private static Dictionary<Job,int> GetJobsActivity((DateTime, DateTime) dates)
		{
			
			return Jobs.ToDictionary(
				job => job,
				job => YearActivities
					.Where(activity => activity.JobId == job.Id && activity.TimeStampCreation >= dates.Item1 && activity.TimeStampCreation <= dates.Item2)
					.Sum(activity => activity.JobCount)
			);
		}

		private static Dictionary<Worker,int> GetWorkersActivity((DateTime, DateTime) dates)
		{
			return Workers.ToDictionary(
				worker => worker,
				worker => YearActivities
					.Where(activity => activity.WorkerId == worker.Id && activity.TimeStampCreation >= dates.Item1 && activity.TimeStampCreation <= dates.Item2)
					.Sum(activity => activity.Duration)
			);
		}

		private static Dictionary<Worker, List<Activity>> GetWorkerActivities(Worker[] workers, Activity[] activities)
		{
			var workerActivities = new Dictionary<Worker, List<Activity>>();
			foreach (var worker in workers)
				workerActivities[worker] = new List<Activity>();
			foreach (var activity in activities)
			{
				var worker = Array.Find(workers, w => w.Id == activity.WorkerId);
				if (worker != null)
					workerActivities[worker].Add(activity);
			}
			return workerActivities;
		}
		
		// Sum methods should just take two datetimes as argument and be thus context independent, I should fix that in the future

		private static int SumActivitiesDuration(Activity[] workerActivities, Constants.DateSpan dateSpan)
		{
			var startDate = Constants.CalculateStartDate(dateSpan);
			return workerActivities
				.Where(activity => activity.TimeStampCreation >= startDate)
				.Sum(activity => activity.Duration);
		}
		/// <summary>
		/// Calculates overtime compensation for a worker in a given period.
		/// Formula: (totalWorkedMinutes - daysWorked * BaseShiftMinutes) / 60 * HourlySalary
		/// A day counts as "worked" only if the worker completed >= MinParcelsForWorkday parcel activities.
		/// Overtime is clamped to 0 (no negative compensation).
		/// </summary>
		private static decimal SumActivitiesEarning(Activity[] workerActivities, Constants.DateSpan dateSpan)
		{
			(DateTime, DateTime) dates = Constants.CalculateLastStartAndEndDate(dateSpan);
			var startDate = dates.Item1;
			var endDate = dates.Item2;

			var periodActivities = workerActivities
				.Where(a => a.TimeStampCreation > startDate && a.TimeStampCreation < endDate)
				.ToList();

			// Total worked minutes from ALL activities
			double totalWorkedMinutes = periodActivities.Sum(a => a.Duration) / 60.0;

			// Parcel job IDs for identifying qualifying workdays
			var parcelJobIds = new HashSet<Guid>
			{
				ParcelJobs.CzechPostParcel.Id,
				ParcelJobs.DpdParcel.Id,
				ParcelJobs.GlsParcel.Id,
				ParcelJobs.ZasilkovnaParcel.Id,
				ParcelJobs.PplParcel.Id
			};

			// Count qualifying workdays: days where worker packed >= MinParcelsForWorkday parcels
			int daysWorked = periodActivities
				.GroupBy(a => a.TimeStampCreation.Date)
				.Count(dayGroup => dayGroup
					.Where(a => parcelJobIds.Contains(a.JobId))
					.Sum(a => a.JobCount) >= AdminSettings.Misc.MinParcelsForWorkday);

			// (totalWorkedMinutes - daysWorked * BaseShiftMinutes) / 60 * HourlySalary
			double overtimeMinutes = totalWorkedMinutes - (daysWorked * AdminSettings.Misc.BaseShiftMinutes);
			overtimeMinutes = Math.Max(0, overtimeMinutes);
			double overtimeHours = overtimeMinutes / 60.0;

			return Convert.ToDecimal(overtimeHours) * Convert.ToDecimal(AdminSettings.Misc.HourlySalary);
		}
		private static int SumParcelsCount(Activity[] workerActvities, Constants.DateSpan dateSpan)
		{
			var startDate = Constants.CalculateStartDate(dateSpan);
			return workerActvities.Where(a => ((a.JobId == ParcelJobs.CzechPostParcel.Id) || (a.JobId == ParcelJobs.DpdParcel.Id) || (a.JobId == ParcelJobs.GlsParcel.Id) || (a.JobId == ParcelJobs.ZasilkovnaParcel.Id) || (a.JobId == ParcelJobs.PplParcel.Id)) && (a.TimeStampCreation > startDate))
			.Sum(a => a.JobCount);
		}

		private static Activity[] GetLatestActivities(int numberOfItems)
		{
			if (numberOfItems <= 0)
				return new Activity[0];

			return YearActivities
				.Where(activity => Constants.CalculateStartDate(Constants.DateSpan.Day) <= activity.TimeStampCreation)
				.OrderByDescending(activity => activity.TimeStampCreation)
				.Take(numberOfItems)
				.ToArray();
		}
		public static string GenerateParcelInformationByVarSym(string varSym)
		{
			FinishedParcel fParcel = YearParcels.FirstOrDefault(p => p.VarSym == varSym);
			if (fParcel == null)
				return null;
			else
			{
				var sb = new StringBuilder();
				sb.AppendLine($"Id: {fParcel.Id.ToString()}");
				sb.AppendLine($"Variabilní symbol: {fParcel.VarSym}");
				sb.AppendLine($"Číslo faktury: {fParcel.OrderNumber}");
				sb.AppendLine($"Vyvořeno zaměstnancem: {GetWorkerNameById(fParcel.WorkerId)} (Id: {fParcel.WorkerId})");
				return sb.ToString();
            }	
		}
		private static string GetWorkerNameById(Guid id)
		{
			Worker worker = GetWorkerById(id);
			if (worker == null)
				return Constants.UndefinedString;
			else
				return worker.Name;
		}
		private static string GetJobNameById(Guid id)
		{
			Job job= GetJobById(id);
			if (job == null)
				return Constants.UndefinedString;
			else
				return job.Name;
		}
		private static Worker GetWorkerById(Guid id)
		{
			return Workers.FirstOrDefault(worker => worker.Id == id);
		}
		private static Activity GetActivityById(Guid id)
		{
			return YearActivities.FirstOrDefault(activity => activity.Id == id);
		}
		private static Job GetJobById(Guid id)
		{
			return Jobs.FirstOrDefault(job => job.Id == id);
		}

		public static class TrackAndTrace
		{
			public static void Log(Parcel parcel, string trackId)
			{
				string log = $"{trackId};{parcel.VariableSymbol};{parcel.OrderNumber};{parcel.CourierName};{parcel.recipient.FirstName} {parcel.recipient.LastName}";
				string path = AssembleCsvPath(AdminSettings.Misc.TrackAndTraceLogPath);
				try
				{
					if (File.Exists(path))
						File.AppendAllText(path, $"\n{log}");
					else
						File.WriteAllText(path, log);
				}
				catch(Exception ex) {
					DialogService.ShowError("Track And Trace", $"Nebylo možné uložit informace pro Track and Trace\n\n{ex.Message}");
				}
			}

			private static string AssembleCsvPath(string baseDir)
			{
				string filename = DateTime.Today.ToString("yyyy");
				filename += DateTime.Today.ToString("MM");
				filename += DateTime.Today.ToString("dd");
				return Path.Join(baseDir, filename + ".csv");
			}
		}
	}
}