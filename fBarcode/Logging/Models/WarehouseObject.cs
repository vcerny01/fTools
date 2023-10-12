	using System;
	using fBarcode.Utils;

	namespace fBarcode.Logging.Models;

	public abstract class WarehouseObject
	{
		public DateTime TimeStampCreation { get; }
		public Guid Id { get; }
		public string Name { get; }

		public WarehouseObject(string name)
		{
			TimeStampCreation = DateTime.Now;
			Name = name;
			Id = new Guid();
		}
		public WarehouseObject(string name, Guid guid, DateTime timeStampCreation)
		{
			TimeStampCreation = timeStampCreation;
			Name = name;
			Id = guid;
		}
	}


