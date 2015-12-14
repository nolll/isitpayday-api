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
            public int? Frequency { get; }
            public string CountryCode { get; }
            public string TimezoneId { get; }

            public Request(int? payDay, int? frequency, string countryCode, string timezoneId)
            {
                PayDay = payDay;
                Frequency = frequency;
                CountryCode = countryCode;
                TimezoneId = timezoneId;
            }
        }

        public Result Execute(Request request)
        {
            var userSettings = new UserSettings(request.PayDay, request.Frequency, request.CountryCode, request.TimezoneId);

            return new Result(
                userSettings.PayDay,
                userSettings.Country,
                userSettings.TimeZone,
                userSettings.Frequency,
                PayDayOptions,
                FrequencyOptions,
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

        private IList<Frequency> FrequencyOptions => new List<Frequency> { Frequency.Monthly, Frequency.Weekly };
        private IList<Country> CountryOptions => CountryService.GetCountries().ToList();
        private IList<TimeZoneInfo> TimeZoneOptions => TimeZoneInfo.GetSystemTimeZones().ToList();

        public class Result
        {
            public int PayDay { get; }
            public Country Country { get; }
            public TimeZoneInfo TimeZone { get; }
            public Frequency Frequency { get; }
            public IList<int> PayDayOptions { get; }
            public IList<Frequency> FrequencyOptions { get; }
            public IList<Country> CountryOptions { get; }
            public IList<TimeZoneInfo> TimeZoneOptions { get; }

            public Result(
                int payDay,
                Country country,
                TimeZoneInfo timeZone,
                Frequency frequency,
                IList<int> payDayOptions,
                IList<Frequency> frequencyOptions,
                IList<Country> countryOptions,
                IList<TimeZoneInfo> timeZoneOptions)
            {
                PayDay = payDay;
                Country = country;
                TimeZone = timeZone;
                Frequency = frequency;
                PayDayOptions = payDayOptions;
                FrequencyOptions = frequencyOptions;
                CountryOptions = countryOptions;
                TimeZoneOptions = timeZoneOptions;
            }
        }
    }
}