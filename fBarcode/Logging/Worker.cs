﻿using System;
namespace fBarcode.Logging
{
	public class Worker : WarehouseObject
	{
		public Worker(string name) : base(name)
		{ }
		public Worker(string name, string guid, DateTime timeStampCreation) : base(name, guid, timeStampCreation)
		{ }
	}
}

