﻿using System;
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
            var userSettings = UserSettingsService.GetSettings(request.PayDay, request.PayDayType, request.CountryCode, request.TimezoneId);

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
            public int PayDay { get; private set; }
            public Country Country { get; private set; }
            public TimeZoneInfo TimeZone { get; private set; }
            public PayDayType PayDayType { get; private set; }
            public IList<int> PayDayOptions { get; private set; }
            public IList<PayDayType> PayDayTypeOptions { get; private set; }
            public IList<Country> CountryOptions { get; private set; }
            public IList<TimeZoneInfo> TimeZoneOptions { get; private set; }

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