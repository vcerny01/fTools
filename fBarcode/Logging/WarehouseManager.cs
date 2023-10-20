using System;
using System.Collections.Generic;
using fBarcode.Fichema;
using fBarcode.Logging;
using Warehouse = fBarcode.Logging.WarehouseService;
using fBarcode.Logging.Models;
using System.Linq;

namespace fBarcode.Logging
{
	public class WarehouseManager
	{
		private List<Activity> _yearActivities;
		private List<FinishedParcel> _yearParcels;
		private List<Worker> _workers;
		private List<Job> _jobs;

		public Worker currentWorker { get; }

		public WarehouseManager()
		{
			_workers = Warehouse.GetWorkers();
			_yearActivities = Warehouse.GetPastActivities();
			_yearParcels = Warehouse.GetFinishedParcels();
			_jobs = Warehouse.GetJobs();
		}
		public void SetWorkers(List<Worker> workers)
		{
			_workers = workers;
			Warehouse.SetWorkers(workers);
		}
		public void SetJobs(List<Job> jobs)
		{
			_jobs = jobs;
			Warehouse.SetJobs(jobs);
		}
		public void AddParcel(Parcel parcel)
		{

		}
		public void AddFinishedParcels(List<FinishedParcel> finishedParcels)
		{
			
		}
		public void AddActivity(Activity activity)
		{

		}
	}
}