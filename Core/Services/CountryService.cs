using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Classes;
using Core.Storage;

namespace Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IStorage _storage;
        private readonly ITimeService _timeService;

        public CountryService(
            IStorage storage,
            ITimeService timeService)
        {
            _storage = storage;
            _timeService = timeService;
        }

        public IEnumerable<Country> GetCountries()
        {
            var countries = from ri in
                            from ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                            select new RegionInfo(ci.LCID)
                            group ri by ri.TwoLetterISORegionName into g
                            select new Country(g.Key, g.First().DisplayName);
            return countries.OrderBy(o => o.Name);
        }

        public Country GetCountry()
        {
            var countryId = _storage.GetCountry();
            if (countryId == null)
            {
                countryId = "SE";
            }
            return GetCountries().FirstOrDefault(o => o.Id == countryId);
        }

        public TimeZoneInfo GetTimeZone()
        {
            var timeZoneId = _storage.GetTimeZone();
            if (timeZoneId == null)
            {
                timeZoneId = "W. Europe Standard Time";
            }
            return _timeService.GetTimezones().FirstOrDefault(o => o.Id == timeZoneId);
        }
    }
}