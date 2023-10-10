using System;
namespace fBarcode.Logging
{
	public class Job : WarehouseObject
	{
        public int Valuation { get; } // CZK per hour
        public Job(string name, int valuation) : base(name)
        {
            Valuation = valuation;
        }
        public Job(string name, string guid, DateTime timeStampCreation, int valuation) : base(name, guid, timeStampCreation)
        {
            Valuation = valuation;
        }
    }
}

