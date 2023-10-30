using System;
using System.Net.Sockets;
namespace fBarcode.Logging.Models
{
	public class FinishedParcel
	{
		public DateTime TimeStampCreation { get; }
		public Guid Id {get; }
		public Guid WorkerId { get; }
		public string OrderNumber { get; }

		public FinishedParcel(DateTime timeStamp, Guid workerId, string orderNumber)
		{
			Id = Guid.NewGuid();
			TimeStampCreation = timeStamp;
			WorkerId = workerId;
			OrderNumber = orderNumber;
		}
		public FinishedParcel(Guid id, DateTime timeStamp, Guid workerId, string orderNumber)
		{
			Id = id;
			TimeStampCreation = timeStamp;
			WorkerId = workerId;
			OrderNumber = orderNumber;
		}
	}
}

