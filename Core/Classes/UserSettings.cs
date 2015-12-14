using System;
using System.Linq;
using Core.Services;

namespace Core.Classes
{
    public class UserSettings
    {
        private const int DefaultPayDay = 25;
        private const Frequency DefaultFrequency = Frequency.Monthly;
        private const string DefaultCountryCode = "SE";
        private const string DefaultTimezone = "W. Europe Standard Time";
        
        public int PayDay { get; }
        public Frequency Frequency { get; }
        public Country Country { get; }
        public TimeZoneInfo TimeZone { get; }

        public UserSettings(int? payDay, int? frequency, string countryCode, string timezoneId)
        {
            PayDay = GetSelectedPayDay(payDay);
            Frequency = GetSelectedFrequency(frequency);
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

        private static Frequency GetSelectedFrequency(int? frequency)
        {
            if (!frequency.HasValue)
                return DefaultFrequency;
            return frequency.Value == 2 ? Frequency.Weekly : Frequency.Monthly;
        }
    }
}
