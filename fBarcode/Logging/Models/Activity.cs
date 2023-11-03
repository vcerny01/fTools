using System;
using System.Net.Sockets;
using System.Windows.Forms;
using fBarcode.Logging;

namespace fBarcode.Logging.Models
{
	public class Activity
	{
		public DateTime TimeStampCreation { get; }
		public Guid Id {get; }
        public Guid JobId { get; }
        public Guid WorkerId { get; }
		public int JobCount { get; }
		public int Duration { get; } // minutes
		public decimal Earning { get; }
		public string OrderNumber { get; }

		public Activity(Job job, Worker worker, int jobCount, string orderNumber = null)
		{
			Id = Guid.NewGuid();
			TimeStampCreation = DateTime.Now;
			WorkerId = worker.Id;
			JobId = job.Id;
			JobCount = jobCount;
			Duration = jobCount * job.DurationInSeconds;
			Earning = Convert.ToDecimal(Duration) / 3600 * Convert.ToDecimal(AdminSettings.Misc.HourlySalary);
			OrderNumber = orderNumber;
		}
        public Activity(Guid id, Guid jobId, Guid workerId, int jobCount, int duration, decimal earning, DateTime timestamp, string orderNumber = null)
        {
			Id = id;
			TimeStampCreation = timestamp;
            WorkerId = workerId;
			JobId = jobId;
			JobCount = jobCount;
            Duration = duration;
            Earning = earning;
            OrderNumber = orderNumber;
        }
    }
}

