using System;
using System.Collections.Generic;
using System.Linq;
using Core.Exceptions;

namespace Core.Services
{
    public static class TimezoneService
    {
        public static IEnumerable<TimeZoneInfo> GetTimezones()
        {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        public static TimeZoneInfo GetTimezone(string id)
        {
            try
            {
                return GetTimezones().First(o => o.Id == id);
            }
            catch (Exception)
            {
                throw new TimezoneNotFoundException(id);
            }
        }
    }
}