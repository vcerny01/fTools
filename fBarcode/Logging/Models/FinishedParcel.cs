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
		public string VarSym { get; }

		public FinishedParcel(Guid workerId, string orderNumber, string varSym)
		{
			Id = Guid.NewGuid();
			TimeStampCreation = DateTime.Now;
			WorkerId = workerId;
			OrderNumber = orderNumber;
			VarSym = varSym;
		}
		public FinishedParcel(Guid id, DateTime timeStamp, Guid workerId, string orderNumber, string varSym)
		{
			TimeStampCreation = timeStamp;
			WorkerId = workerId;
			Id = id;
			OrderNumber = orderNumber;
			VarSym = varSym;
		}
	}
}

