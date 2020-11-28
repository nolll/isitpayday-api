using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Classes;
using Core.DateEvaluators;
using Core.Exceptions;

namespace Core.Services
{
    public static class CountryService
    {
        public static IEnumerable<Country> GetCountries()
        {
            var countries = from ri in
                            from ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                            select new RegionInfo(ci.Name)
                            group ri by ri.TwoLetterISORegionName into g
                            select new Country(g.Key, g.First().DisplayName);
            return countries.Where(IsEnabled).OrderBy(o => o.Name);
        }

        private static bool IsEnabled(Country country)
        {
            return HolidayEvaluator.Evaluators.ContainsKey(country.Id);
        }

        public static Country GetCountry(string countryCode)
        {
            try
            {
                return GetCountries().First(o => o.Id == countryCode);
            }
            catch (Exception)
            {
                throw new CountryNotFoundException(countryCode);
            }
        }
    }
}