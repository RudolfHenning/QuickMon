using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.MeansurementUnits
{
    public enum TimeUnits
    {
        Millisecond,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year,
        Century,
        Millenium
    }
    public static class TimeUnitsTools
    {
        public static DateTime AddTime(DateTime sourceTime, long addAmount, TimeUnits unit)
        {
            switch (unit)
            {
                case TimeUnits.Millisecond:
                    return sourceTime.AddMilliseconds(addAmount);
                case TimeUnits.Second:
                    return sourceTime.AddSeconds(addAmount);
                case TimeUnits.Minute:
                    return sourceTime.AddMinutes(addAmount);
                case TimeUnits.Hour:
                    return sourceTime.AddHours(addAmount);
                case TimeUnits.Day:
                    return sourceTime.AddDays(addAmount);
                case TimeUnits.Week:
                    return sourceTime.AddDays(addAmount * 7);
                case TimeUnits.Month:
                    return sourceTime.AddMonths((int)addAmount);
                case TimeUnits.Year:
                    return sourceTime.AddYears((int)addAmount);
                case TimeUnits.Century:
                    return sourceTime.AddYears((int)addAmount * 100);
                case TimeUnits.Millenium:
                    return sourceTime.AddYears((int)addAmount * 1000);
                default:
                    return sourceTime;
            }
        }
    }

    public enum FileSizeUnits
    {
        Bytes,
        KB,
        MB,
        GB
    }
    public static class FileSizeUnitsTools
    {
        public static long ToBytes(FileSizeUnits unit, long amount = 1)
        {
            switch (unit)
            {
                case FileSizeUnits.KB:
                    return amount * 1024;
                case FileSizeUnits.MB:
                    return amount * 1024 * 1024;
                case FileSizeUnits.GB:
                    return amount * 1024 * 1024 * 1024;
                default:
                    return amount;
            }
        }
    }
}
