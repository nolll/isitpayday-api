using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetTime()
        {
            return DateTime.UtcNow;
        }

        public DateTime GetTime(TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, timeZone);
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