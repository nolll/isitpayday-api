using System;
using System.Collections.Generic;
using Core.Services;

namespace Infrastructure.System.Services
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