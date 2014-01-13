using System;
using System.Collections.Generic;

namespace Web.Services
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

        public DateTime Parse(string str, TimeZoneInfo timezone = null)
        {
            var dateTime = DateTime.Parse(str);
            return Convert(dateTime, timezone);
        }

        public DateTime ConvertToUtc(DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeToUtc(dateTime);
        }

        public IEnumerable<TimeZoneInfo> GetTimezones()
        {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        private DateTime Convert(DateTime dateTime, TimeZoneInfo timezone = null)
        {
            return timezone != null ? TimeZoneInfo.ConvertTime(dateTime, timezone) : dateTime;
        }

    }

}