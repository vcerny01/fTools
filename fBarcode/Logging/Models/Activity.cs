using System;
using fBarcode.Logging;

namespace fBarcode.Logging.Models
{
	public class Activity
	{
		public DateTime TimeStampCreation { get; }
		public Guid Id { get; }
		public Guid JobId { get; }
		public Guid WorkerId { get; }
		public int JobCount { get; }
		public int Duration { get; } // seconds
		public decimal Earning { get; }
		public string OrderNumber { get; }
		public string Description { get; }
		public DateTime? DurationFrom { get; }
		public DateTime? DurationTo { get; }

		/// <summary>
		/// Legacy job-count constructor. Keep this for old user jobs and penalizations where duration
		/// still comes from Job.DurationInSeconds.
		/// </summary>
		public Activity(Job job, Worker worker, int jobCount, string orderNumber = null)
		{
			Id = Guid.NewGuid();
			TimeStampCreation = DateTime.Now;
			WorkerId = worker.Id;
			JobId = job.Id;
			JobCount = jobCount;
			Duration = jobCount * job.DurationInSeconds;
			Earning = CalculateLegacyEarning(Duration);
			OrderNumber = orderNumber;
		}

		/// <summary>
		/// Current parcel/custom-duration constructor. Parcel activities keep carrier job IDs for reports,
		/// but their duration is calculated by parcel rules rather than Job.DurationInSeconds.
		/// </summary>
		public Activity(Job job, Worker worker, int jobCount, int customDurationSeconds, string orderNumber = null)
		{
			Id = Guid.NewGuid();
			TimeStampCreation = DateTime.Now;
			WorkerId = worker.Id;
			JobId = job.Id;
			JobCount = jobCount;
			Duration = customDurationSeconds;
			Earning = CalculateLegacyEarning(Duration);
			OrderNumber = orderNumber;
		}

		/// <summary>
		/// Current manual activity constructor. Workers describe the work and enter actual time worked;
		/// payout is calculated later from Duration, not from Job.DurationInSeconds.
		/// </summary>
		public Activity(Job job, Worker worker, string description, DateTime durationFrom, int durationMinutes)
		{
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException("Description is required for manual activities.", nameof(description));
			if (durationMinutes <= 0)
				throw new ArgumentOutOfRangeException(nameof(durationMinutes), "Duration must be positive.");

			Id = Guid.NewGuid();
			TimeStampCreation = DateTime.Now;
			WorkerId = worker.Id;
			JobId = job.Id;
			JobCount = 1;
			Duration = durationMinutes * 60;
			Earning = CalculateLegacyEarning(Duration);
			Description = description.Trim();
			DurationFrom = durationFrom;
			DurationTo = durationFrom.AddMinutes(durationMinutes);
		}

		public Activity(Job job, Worker worker, int jobCount, string description, DateTime durationFrom, int durationMinutes)
		{
			if (jobCount <= 0)
				throw new ArgumentOutOfRangeException(nameof(jobCount), "Job count must be positive.");
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException("Description is required for manual activities.", nameof(description));
			if (durationMinutes <= 0)
				throw new ArgumentOutOfRangeException(nameof(durationMinutes), "Duration must be positive.");

			Id = Guid.NewGuid();
			TimeStampCreation = DateTime.Now;
			WorkerId = worker.Id;
			JobId = job.Id;
			JobCount = jobCount;
			Duration = durationMinutes * 60;
			Earning = CalculateLegacyEarning(Duration);
			Description = description.Trim();
			DurationFrom = durationFrom;
			DurationTo = durationFrom.AddMinutes(durationMinutes);
		}

		public Activity(Guid id, Guid jobId, Guid workerId, int jobCount, int duration, decimal earning, DateTime timestamp, string orderNumber = null, string description = null, DateTime? durationFrom = null, DateTime? durationTo = null)
		{
			Id = id;
			TimeStampCreation = timestamp;
			WorkerId = workerId;
			JobId = jobId;
			JobCount = jobCount;
			Duration = duration;
			Earning = earning;
			OrderNumber = orderNumber;
			Description = string.IsNullOrWhiteSpace(description) ? null : description;
			DurationFrom = durationFrom;
			DurationTo = durationTo;
		}

		/// <summary>
		/// Compatibility-only row earning. Current payout reports recompute overtime from durations.
		/// </summary>
		private static decimal CalculateLegacyEarning(int durationSeconds)
		{
			return Convert.ToDecimal(durationSeconds) / 3600 * Convert.ToDecimal(AdminSettings.Misc.HourlySalary);
		}
	}
}
