using System;
using System.Collections.Generic;
using fBarcode.Fichema;
using fBarcode.Logging;
using WService = fBarcode.Logging.WarehouseService;
using fBarcode.Logging.Models;
using System.Linq;
using fBarcode.Utils;

namespace fBarcode.Logging
{
	public static class WarehouseManager
	{
		private static List<Activity> YearAcvtivities;
		private static List<Guid> AllActivityIds;
		private static List<FinishedParcel> YearParcels;
		private static List<Guid> AllParcelIds;
		public static List<Worker> Workers { get; private set; }
		public static List<Job> Jobs { get; private set; }

		public static Worker ActiveWorker { get; }

		static WarehouseManager()
		{
			Setup();
		}
		private static void Setup()
		{
			Workers = WService.GetWorkers();
			YearAcvtivities = WService.GetPastActivities(DateTime.Now.AddYears(-1));
			YearParcels = WService.GetFinishedParcels(DateTime.Now.AddYears(-1));
			Jobs = WService.GetJobs();
			AllActivityIds = WService.GetPastActivities().Select(activity => activity.Id).ToList();
        	AllParcelIds = WService.GetFinishedParcels().Select(parcel => parcel.Id).ToList();
		}
		public static void CheckIntegrity()
		{
			// TO DO
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
			YearAcvtivities.Add(activity);
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
						YearAcvtivities.Add(activity);
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
		}
	}
}