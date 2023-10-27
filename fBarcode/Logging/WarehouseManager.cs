using System;
using System.Collections.Generic;
using fBarcode.Fichema;
using fBarcode.Logging;
using WService = fBarcode.Logging.WarehouseService;
using fBarcode.Logging.Models;
using System.Linq;
using System.DirectoryServices;

namespace fBarcode.Logging
{
	public static class WarehouseManager
	{
		private static List<Activity> YearAcvtivities;
		private static List<FinishedParcel> YearParcels;
		public static List<Worker> Workers { get; private set; }
		public static List<Job> Jobs { get; private set; }

		public static Worker currentWorker { get; }

		static WarehouseManager()
		{
			Workers = WService.GetWorkers();
			YearAcvtivities = WService.GetPastActivities(DateTime.Now.AddYears(-1), DateTime.Now);
			YearParcels = WService.GetFinishedParcels(DateTime.Now.AddYears(-1), DateTime.Now);
			Jobs = WService.GetJobs();
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
		public static void AddFinishedParcel(Parcel parcel)
		{

		}
		public static void AddFinishedParcels(FinishedParcel[] finishedParcels)
		{
			
		}
		public static void AddActivity(Activity activity)
		{

		}
		public static void AddActivities(Activity[] activities)
		{

		}
		public static void DeleteItem(Type type, Guid id)
		{
			
		}
	}
}