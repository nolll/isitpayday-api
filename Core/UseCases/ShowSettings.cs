using System;
using System.Collections.Generic;
using Core.Classes;
using Core.Services;
using System.Linq;

namespace Core.UseCases
{
    public class Options
    {
        public Result Execute()
        {
            return new Result(
                CountryOptions,
                TimeZoneOptions);
        }

        public class Result
        {
            public IList<Country> CountryOptions { get; }
            public IList<TimeZoneInfo> TimeZoneOptions { get; }

            public Result(
                IList<Country> countryOptions,
                IList<TimeZoneInfo> timeZoneOptions)
            {
                CountryOptions = countryOptions;
                TimeZoneOptions = timeZoneOptions;
            }
        }

        private IList<Country> CountryOptions => CountryService.GetCountries().ToList();
        private IList<TimeZoneInfo> TimeZoneOptions => TimeZoneInfo.GetSystemTimeZones().ToList();
    }
}