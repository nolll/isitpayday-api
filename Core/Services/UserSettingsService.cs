using System;
using System.Linq;
using Core.Classes;
using Core.Storage;

namespace Core.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private const int DefaultPayDay = 25;
        
        private readonly IStorage _storage;

        public UserSettingsService(IStorage storage)
        {
            _storage = storage;
        }

        public UserSettings GetSettings()
        {
            var country = GetCountry();
            var timeZone = GetTimeZone();
            var payDay = GetSelectedPayDay();
            var payDayType = GetSelectedPayDayType();
            return new UserSettings(country, timeZone, payDay, payDayType);
        }

        public static UserSettings GetSettings(int? payDay, int? payDayType, string countryCode, string timezoneId)
        {
            var country = GetCountry(countryCode);
            var timeZone = GetTimeZone(timezoneId);
            var selectedPayDay = GetSelectedPayDay(payDay);
            var selectedPayDayType = GetSelectedPayDayType(payDayType);
            return new UserSettings(country, timeZone, selectedPayDay, selectedPayDayType);
        }

        private Country GetCountry()
        {
            var countryCode = _storage.GetCountry() ?? "SE";
            return GetCountry(countryCode);
        }

        private static Country GetCountry(string countryCode)
        {
            return CountryService.GetCountries().FirstOrDefault(o => o.Id == countryCode);
        }

        private TimeZoneInfo GetTimeZone()
        {
            var timezoneId = _storage.GetTimeZone() ?? "W. Europe Standard Time";
            return GetTimeZone(timezoneId);
        }

        private static TimeZoneInfo GetTimeZone(string timezoneId)
        {
            return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(o => o.Id == timezoneId);
        }

        private int GetSelectedPayDay()
        {
            return GetSelectedPayDay(_storage.GetPayDay());
        }
        
        public static int GetSelectedPayDay(int? payDay)
        {
            return payDay ?? DefaultPayDay;
        }

        private PayDayType GetSelectedPayDayType()
        {
            var payDayType = _storage.GetPayDayType();
            return GetSelectedPayDayType(payDayType);
        }

        private static PayDayType GetSelectedPayDayType(int? payDayType)
        {
            return payDayType.HasValue && payDayType.Value == 2 ? PayDayType.Weekly : PayDayType.Monthly;
        }
    }
}