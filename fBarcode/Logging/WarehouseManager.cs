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
		private static Dictionary<Worker, List<Activity>>  WorkerActivities;
		public static Worker ActiveWorker { get; private set;}
		public static Job ActiveJob {get; private set;}

		public static class ParcelJobs
		{
			public static Job CzechPostParcel;
			public static Job DpdParcel;
			public static Job GlsParcel;
			public static Job ZasilkovnaParcel;
		}

		static WarehouseManager()
		{
			Setup();
		}
		private static void Setup()
		{
			Workers = WService.GetWorkers();
			Jobs = WService.GetJobs();
			YearActivities = WService.GetPastActivities(DateTime.Now.AddYears(-1));
			YearParcels = WService.GetFinishedParcels(DateTime.Now.AddYears(-1));
			AllActivityIds = WService.GetPastActivities().Select(activity => activity.Id).ToList();
        	AllParcelIds = WService.GetFinishedParcels().Select(parcel => parcel.Id).ToList();
			WorkerActivities = GetWorkerActivities(Workers.ToArray(), YearActivities.ToArray());

			ParcelJobs.CzechPostParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.CzechPost);
			ParcelJobs.DpdParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.Dpd);
			ParcelJobs.GlsParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.Gls);
			ParcelJobs.ZasilkovnaParcel = Jobs.FirstOrDefault(job => job.Name == ParcelJobNames.Zasilkovna);
		}
		public static void CheckIntegrity()
		{
			if (Workers.Count == 0)
				SetWorkers(CsvService.Import.LoadWorkers());
			if (Jobs.Count == 0)
				SetJobs(CsvService.Import.LoadJobs());
		}
		public static void SetWorkers(Worker[] workers)
		{
			Workers = new List<Worker>(workers);
			WService.SetWorkers(Workers);
		}
		public static void SetJobs(Job[] jobs)
		{
			Jobs = new List<Job>(jobs);
			WService.SetJobs(Jobs);
		}
		public static void AddParcel(Parcel parcel)
		{
			var fParcel = new FinishedParcel(DateTime.Now, ActiveWorker.Id, parcel.OrderNumber);
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
				ParcelJobNames.Zasilkovna
			};

			return Jobs
				.Where(job => !excludedJobNames.Contains(job.Name))
				.Select(job => new KeyValuePair<Guid, string>(job.Id, job.Name))
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
			var todayDuration = SumActivityDuration(activeWorkerActivities, Constants.DateSpan.Day);
			var todayEarning = SumActivityEarning(activeWorkerActivities, Constants.DateSpan.Day);
			var monthEarning = SumActivityEarning(activeWorkerActivities, Constants.DateSpan.Month);
			var weekPercentile = CalculateWorkerPercentile(ActiveWorker, WorkerActivities);
			sb.AppendLine($"Za dnešek odpracováno: {todayDuration / 60} min");
			sb.AppendLine($"   => {todayEarning} Kč");
			sb.AppendLine($"Celkový výdělek za poslední měsíc: {monthEarning} Kč");
			sb.AppendLine($"Týdenní percentil výkonnosti: {weekPercentile}%");
			return sb.ToString();
		}
		public static string GenerateLogText()
		{
			Activity[] latestActivites = GetLatestActivities(12);
			var sb = new StringBuilder();
			foreach (Activity a in latestActivites)
			{
				var jobName = GetJobById(a.JobId).Name;
				var workerName = GetWorkerById(a.WorkerId).Name;
				if (jobName.Length > 15)
					jobName = jobName.Substring(0, 12) + "...";
				if (workerName.Length > 15)
					workerName = workerName.Substring(0, 12) + "...";
				sb.AppendLine($"{a.TimeStampCreation.Hour}:{a.TimeStampCreation.Minute}   {workerName}: {jobName}   {a.Duration / 60} min");
			}
			return sb.ToString();
		}
		public static string GenerateReportText(Constants.DateSpan dateSpan)
		{
			var sb = new StringBuilder();
			
			
			// TO DO
			return sb.ToString();
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
		private static int SumActivityDuration(Activity[] workerActivities, Constants.DateSpan dateSpan)
		{
			DateTime startDate = Constants.CalculateStartDate(dateSpan);
			return workerActivities
				.Where(activity => activity.TimeStampCreation >= startDate)
				.Sum(activity => activity.Duration);
		}
		private static decimal SumActivityEarning(Activity[] workerActivities, Constants.DateSpan dateSpan)
		{
			DateTime startDate = Constants.CalculateStartDate(dateSpan);
			return workerActivities
				.Where(activity => activity.TimeStampCreation >= startDate)
				.Sum(activity => activity.Earning); 
		}
		private static double CalculateWorkerPercentile(Worker worker, Dictionary<Worker, List<Activity>> workerActivities)
		{
			var allDurations = workerActivities.Values.SelectMany(activities => activities)
				.Select(activity => activity.Duration)
				.OrderBy(duration => duration)
				.ToList();
			double percentile = (allDurations.IndexOf(SumActivityDuration(workerActivities[worker].ToArray(), Constants.DateSpan.Month)) + 1) / (double)allDurations.Count * 100.0;
			return percentile;
		}
		private static Activity[] GetLatestActivities(int numberOfItems)
		{
			if (numberOfItems <= 0)
				return new Activity[0];

			return YearActivities
				.OrderByDescending(activity => activity.TimeStampCreation)
				.Take(numberOfItems)
				.ToArray();
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
	}
}