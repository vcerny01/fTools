using System;
using System.Collections.Generic;
using fBarcode.Fichema;
using fBarcode.Logging;
using Warehouse = fBarcode.Logging.WarehouseService;
using fBarcode.Logging.Models;

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
			_yearActivities = Warehouse.GetPastActivities();
			_yearParcels = Warehouse.GetFinishedParcels();
			_workers = Warehouse.GetWorkers();
			_jobs = Warehouse.GetJobs();
		}

		public void AddParcel(Parcel parcel)
		{

		}
		public void AddActivity(Activity activity)
		{

		}
	}
}

