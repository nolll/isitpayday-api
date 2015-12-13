using System;
using System.Linq;
using Core.Classes;

namespace Core.Services
{
    public class UserSettingsService
    {
        private const int DefaultPayDay = 25;
        
        public static UserSettings GetSettings(int? payDay, int? payDayType, string countryCode, string timezoneId)
        {
            var country = GetCountry(countryCode);
            var timeZone = GetTimeZone(timezoneId);
            var selectedPayDay = GetSelectedPayDay(payDay);
            var selectedPayDayType = GetSelectedPayDayType(payDayType);
            return new UserSettings(country, timeZone, selectedPayDay, selectedPayDayType);
        }

        private static Country GetCountry(string countryCode)
        {
            var c = countryCode ?? "SE";
            return CountryService.GetCountries().FirstOrDefault(o => o.Id == c);
        }

        private static TimeZoneInfo GetTimeZone(string timezoneId)
        {
            var t = timezoneId ?? "W. Europe Standard Time";
            return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(o => o.Id == t);
        }

        public static int GetSelectedPayDay(int? payDay)
        {
            return payDay ?? DefaultPayDay;
        }

        private static PayDayType GetSelectedPayDayType(int? payDayType)
        {
            if(!payDayType.HasValue)
                return PayDayType.Monthly;
            return payDayType.Value == 2 ? PayDayType.Weekly : PayDayType.Monthly;
        }
    }
}