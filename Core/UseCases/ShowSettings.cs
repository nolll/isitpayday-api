using System;
using System.Collections.Generic;
using Core.Classes;
using Core.Services;
using System.Linq;

namespace Core.UseCases
{
    public class ShowSettings
    {
        public class Request
        {
            public int? PayDay { get; }
            public int? PayDayType { get; }
            public string CountryCode { get; }
            public string TimezoneId { get; }

            public Request(int? payDay, int? payDayType, string countryCode, string timezoneId)
            {
                PayDay = payDay;
                PayDayType = payDayType;
                CountryCode = countryCode;
                TimezoneId = timezoneId;
            }
        }

        public Result Execute(Request request)
        {
            var userSettings = new UserSettings(request.PayDay, request.PayDayType, request.CountryCode, request.TimezoneId);

            return new Result(
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

        private IList<PayDayType> PayDayTypeOptions => new List<PayDayType> { PayDayType.Monthly, PayDayType.Weekly };
        private IList<Country> CountryOptions => CountryService.GetCountries().ToList();
        private IList<TimeZoneInfo> TimeZoneOptions => TimeZoneInfo.GetSystemTimeZones().ToList();

        public class Result
        {
            public int PayDay { get; }
            public Country Country { get; }
            public TimeZoneInfo TimeZone { get; }
            public PayDayType PayDayType { get; }
            public IList<int> PayDayOptions { get; }
            public IList<PayDayType> PayDayTypeOptions { get; }
            public IList<Country> CountryOptions { get; }
            public IList<TimeZoneInfo> TimeZoneOptions { get; }

            public Result(
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
}