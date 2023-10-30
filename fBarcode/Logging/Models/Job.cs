using System;
namespace fBarcode.Logging.Models
{
    public class Job : WarehouseObject
    {
        public int DurationInSeconds { get; } // CZK per hour
        public Job(string name, int duration) : base(name)
        {
            DurationInSeconds = duration;
        }
        public Job(string name, Guid guid, int duration, DateTime timeStampCreation) : base(name, guid, timeStampCreation)
        {
            DurationInSeconds = duration;
        }
    }
}