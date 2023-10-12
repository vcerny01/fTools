using System;
namespace fBarcode.Logging.Models
{
	public class FinishedParcel
	{
		public DateTime TimeStampCreation { get; }
		public Guid WorkerId { get; }
		public string OrderNumber { get; }

		public FinishedParcel(DateTime timeStamp, Guid id, string orderNumber)
		{
			TimeStampCreation = timeStamp;
			WorkerId = id;
			OrderNumber = orderNumber;
		}
	}
}

