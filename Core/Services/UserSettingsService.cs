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

        private Country GetCountry()
        {
            var countryId = _storage.GetCountry() ?? "SE";
            return CountryService.GetCountries().FirstOrDefault(o => o.Id == countryId);
        }

        private TimeZoneInfo GetTimeZone()
        {
            var timeZoneId = _storage.GetTimeZone() ?? "W. Europe Standard Time";
            return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(o => o.Id == timeZoneId);
        }

        private int GetSelectedPayDay()
        {
            var payday = _storage.GetPayDay();
            return payday.HasValue ? payday.Value : DefaultPayDay;
        }

        private PayDayType GetSelectedPayDayType()
        {
            var payDayType = _storage.GetPayDayType();
            return payDayType.HasValue && payDayType.Value == 2 ? PayDayType.Weekly : PayDayType.Monthly;
        }
    }
}