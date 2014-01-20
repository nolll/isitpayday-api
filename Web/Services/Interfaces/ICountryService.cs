using System;
using System.Collections.Generic;
using Core.Classes;

namespace Web.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
        Country GetCountry();
        TimeZoneInfo GetTimeZone();
    }
}