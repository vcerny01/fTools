using System;
using System.Collections.Generic;
using fBarcode.Fichema;
using fBarcode.Logging;
using Warehouse = fBarcode.Logging.WarehouseService;
using fBarcode.Logging.Models;
using System.Linq;

namespace fBarcode.Logging
{
	public static class WarehouseManager
	{
		private static List<Activity> _yearActivities;
		private static List<FinishedParcel> _yearParcels;
		private static List<Worker> _workers;
		private static List<Job> _jobs;

		public static Worker currentWorker { get; }

		static WarehouseManager()
		{
			_workers = Warehouse.GetWorkers();
			_yearActivities = Warehouse.GetPastActivities();
			_yearParcels = Warehouse.GetFinishedParcels();
			_jobs = Warehouse.GetJobs();
		}
		public static void CheckIntegrity()
		{
			// TO DO
		}
		public static void SetWorkers(Worker[] workers)
		{
			_workers = new List<Worker>(workers);
			Warehouse.SetWorkers(_workers);
		}
		public static void SetJobs(Job[] jobs)
		{
			_jobs = new List<Job>(jobs);
			Warehouse.SetJobs(_jobs);
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
	}
}