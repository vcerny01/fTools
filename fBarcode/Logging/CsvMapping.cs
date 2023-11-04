using fBarcode.Logging.Models;
using fBarcode.Utils;
using CsvHelper.Configuration;
using System;
using CsvHelper.TypeConversion;
using CsvHelper;

namespace fBarcode.Logging
{
    public class WorkerMap : ClassMap<Worker>
    {
        public WorkerMap()
        {
			Map(m => m.Name);
			Map(m => m.Id);
			Map(m => m.TimeStampCreation).TypeConverter<DateTimeToUnixSecondsConverter>();
		}
	}
	public class JobMap : ClassMap<Job>
	{
		public JobMap()
		{
			Map(m => m.Name);
			Map(m => m.Id);
			Map(m => m.DurationInSeconds);
			Map(m => m.TimeStampCreation).TypeConverter<DateTimeToUnixSecondsConverter>();
		}
	}
	public class ActivityMap : ClassMap<Activity>
	{
		public ActivityMap()
		{
			Map(m => m.Id);
			Map(m => m.JobId);
			Map(m => m.WorkerId);
			Map(m => m.JobCount);
			Map(m => m.Duration);
			Map(m => m.Earning);
			Map(m => m.TimeStampCreation).TypeConverter<DateTimeToUnixSecondsConverter>();
			Map(m => m.OrderNumber);
		}
	}
	public class FinishedParcelMap : ClassMap<FinishedParcel>
	{
		public FinishedParcelMap()
		{
			Map(m => m.Id);
			Map(m => m.WorkerId);
			Map(m => m.OrderNumber);
			Map(m => m.VarSym);
			Map(m => m.TimeStampCreation).TypeConverter<DateTimeToUnixSecondsConverter>();
		}
	}
	public class DateTimeToUnixSecondsConverter : DefaultTypeConverter
	{
		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (value is DateTime dateTime)
			{
				DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				TimeSpan timeSinceEpoch = dateTime.ToUniversalTime() - unixEpoch;
				return ((long)timeSinceEpoch.TotalSeconds).ToString();
			}
			return base.ConvertToString(value, row, memberMapData);
		}
	}
}
