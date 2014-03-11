using System;
using System.Linq;
using Core.Classes;
using Core.Storage;

namespace Core.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private const int DefaultPayDay = 25;
        
        private readonly ICountryService _countryService;
        private readonly ITimeService _timeService;
        private readonly IStorage _storage;

        public UserSettingsService(
            ICountryService countryService,
            ITimeService timeService,
            IStorage storage)
        {
            _countryService = countryService;
            _timeService = timeService;
            _storage = storage;
        }

        public UserSettings GetSettings()
        {
            var country = GetCountry();
            var timeZone = GetTimeZone();
            var payDay = GetSelectedPayDay();
            return new UserSettings(country, timeZone, payDay);
        }

        private Country GetCountry()
        {
            var countryId = _storage.GetCountry() ?? "SE";
            return _countryService.GetCountries().FirstOrDefault(o => o.Id == countryId);
        }

        private TimeZoneInfo GetTimeZone()
        {
            var timeZoneId = _storage.GetTimeZone() ?? "W. Europe Standard Time";
            return _timeService.GetTimezones().FirstOrDefault(o => o.Id == timeZoneId);
        }

        private int GetSelectedPayDay()
        {
            var payday = _storage.GetPayDay();
            return payday.HasValue ? payday.Value : DefaultPayDay;
        }
    }
}