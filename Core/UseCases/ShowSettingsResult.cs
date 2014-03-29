using System;
using System.Collections.Generic;
using Core.Classes;

namespace Core.UseCases
{
    public class ShowSettingsResult
    {
        public int PayDay { get; private set; }
        public Country Country { get; private set; }
        public TimeZoneInfo TimeZone { get; private set; }
        public PayDayType PayDayType { get; private set; }
        public IList<int> PayDayOptions { get; private set; }
        public IList<PayDayType> PayDayTypeOptions { get; private set; }
        public IList<Country> CountryOptions { get; private set; }
        public IList<TimeZoneInfo> TimeZoneOptions { get; private set; }

        public ShowSettingsResult(
            int payDay,
            Country country,
            TimeZoneInfo timeZone,
            PayDayType payDayType,
            IList<int> payDayOptions,
            IList<PayDayType> payDayTypeOptions,
            IList<Country> countryOptions,
            IList<TimeZoneInfo> timeZoneOptions)
        {
            PayDay = payDay;
            Country = country;
            TimeZone = timeZone;
            PayDayType = payDayType;
            PayDayOptions = payDayOptions;
            PayDayTypeOptions = payDayTypeOptions;
            CountryOptions = countryOptions;
            TimeZoneOptions = timeZoneOptions;
        }
    }
}