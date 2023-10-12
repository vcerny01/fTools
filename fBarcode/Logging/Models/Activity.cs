using System;
namespace fBarcode.Logging.Models
{
	public class Activity
	{
		public DateTime TimeStampCreation { get; }
        public Guid JobId { get; }
        public Guid WorkerId { get; }
		public int Duration { get; } // minutes
		public decimal Earning { get; }
		public string OrderNumber { get; }

		public Activity(Job job, Worker worker, int duration, string orderNumber = null)
		{
			TimeStampCreation = DateTime.Now;
			WorkerId = worker.Id;
			JobId = job.Id;
			Duration = duration;
			Earning = (duration / 60 * job.Valuation);
			OrderNumber = orderNumber;
		}
        public Activity(Guid jobId, Guid workerId, int duration, decimal earning, DateTime timestamp, string orderNumber = null)
        {
			TimeStampCreation = timestamp;
            WorkerId = workerId;
			JobId = jobId;
            Duration = duration;
            Earning = earning;
            OrderNumber = orderNumber;
        }

    }
}

