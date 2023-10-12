using System;
namespace fBarcode.Logging.Models
{
	public class Worker : WarehouseObject
	{
		public Worker(string name) : base(name)
		{ }
		public Worker(string name, Guid guid, DateTime timeStampCreation) : base(name, guid, timeStampCreation)
		{ }
	}
}