using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Classes;
using Core.Exceptions;

namespace Core.Services
{
    public static class CountryService
    {
        public static IEnumerable<Country> GetCountries()
        {
            var countries = from ri in
                            from ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                            select new RegionInfo(ci.LCID)
                            group ri by ri.TwoLetterISORegionName into g
                            select new Country(g.Key, g.First().DisplayName);
            return countries.OrderBy(o => o.Name);
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