using fBarcode.Logging.Models;
using fBarcode.Utils;
using CsvHelper.Configuration;
using System;

namespace fBarcode.Logging
{
    public class WorkerMap : ClassMap<Worker>
    {
        public WorkerMap()
        {
            AutoMap(Constants.CsvConfig);
        }
    }
}
