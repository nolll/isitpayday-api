using System;
using System.Linq;
using Core.Services;

namespace Core.Classes
{
    public class UserSettings
    {
        private const int DefaultPayDay = 25;
        private const string DefaultCountryCode = "SE";
        private const string DefaultTimezone = "W. Europe Standard Time";
        
        public int PayDay { get; }
        public Country Country { get; }
        public TimeZoneInfo TimeZone { get; }

        public UserSettings(int? payDay, string countryCode, string timezoneId)
        {
            PayDay = GetSelectedPayDay(payDay);
            Country = GetCountry(countryCode);
            TimeZone = GetTimeZone(timezoneId);
        }

        private static Country GetCountry(string countryCode)
        {
            var c = countryCode ?? DefaultCountryCode;
            return CountryService.GetCountries().FirstOrDefault(o => o.Id == c);
        }

        private static TimeZoneInfo GetTimeZone(string timezoneId)
        {
            var t = timezoneId ?? DefaultTimezone;
            return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(o => o.Id == t);
        }

        private static int GetSelectedPayDay(int? payDay)
        {
            return payDay ?? DefaultPayDay;
        }
    }
}
