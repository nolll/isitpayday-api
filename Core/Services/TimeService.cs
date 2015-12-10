using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetUtcTime()
        {
            return DateTime.UtcNow;
        }

        public DateTime GetLocalTime(TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTime(GetUtcTime(), timeZone);
        }

        public static DateTime GetLocalTime(DateTime utcTime, TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTime(utcTime, timeZone);
        }

        public IEnumerable<TimeZoneInfo> GetTimezones()
        {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        public int GetCurrentYear()
        {
            return DateTime.Now.Year;
        }
    }
}