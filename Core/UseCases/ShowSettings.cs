using System;
using System.Collections.Generic;
using Core.Classes;
using Core.Services;
using System.Linq;

namespace Core.UseCases
{
    public class ShowSettings : IShowSettings
    {
        private readonly IUserSettingsService _userSettingsService;
        private readonly ICountryService _countryService;
        private readonly ITimeService _timeService;

        public ShowSettings(
            IUserSettingsService userSettingsService,
            ICountryService countryService,
            ITimeService timeService)
        {
            _userSettingsService = userSettingsService;
            _countryService = countryService;
            _timeService = timeService;
        }

        public ShowSettingsResult Execute()
        {
            var userSettings = _userSettingsService.GetSettings();

            return new ShowSettingsResult(
                userSettings.PayDay,
                userSettings.Country,
                userSettings.TimeZone,
                userSettings.PayDayType,
                PayDayOptions,
                PayDayTypeOptions,
                CountryOptions,
                TimeZoneOptions);
        }

        private IList<int> PayDayOptions
        {
            get
            {
                var items = new List<int>();
                for (var i = 1; i <= 31; i++)
                {
                    items.Add(i);
                }
                return items;
            }
        }

        private IList<PayDayType> PayDayTypeOptions
        {
            get
            {
                return new List<PayDayType>
                    {
                        PayDayType.Monthly,
                        PayDayType.Weekly
                    };
            }
        }

        private IList<Country> CountryOptions
        {
            get { return _countryService.GetCountries().ToList(); }
        }

        private IList<TimeZoneInfo> TimeZoneOptions
        {
            get { return _timeService.GetTimezones().ToList(); }
        }
    }
}