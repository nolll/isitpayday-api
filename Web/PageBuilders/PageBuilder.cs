﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Core.Services;
using Web.ModelFactories;
using Web.Models;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private const string CountryFormName = "country";
        private const string TimeZoneFormName = "timezone";
        private const string PayDayFormName = "payday";

        private readonly IPayDayService _payDayService;
        private readonly ITimeService _timeService;
        private readonly ICountryService _countryService;
        private readonly IGoogleAnalyticsModelFactory _googleAnalyticsModelFactory;

        public PageBuilder(
            IPayDayService payDayService,
            ITimeService timeService,
            ICountryService countryService,
            IGoogleAnalyticsModelFactory googleAnalyticsModelFactory)
        {
            _payDayService = payDayService;
            _timeService = timeService;
            _countryService = countryService;
            _googleAnalyticsModelFactory = googleAnalyticsModelFactory;
        }

        public IndexPageModel Build(string activeForm)
        {
            var timeZone = _countryService.GetTimeZone();
            var timeZoneId = timeZone.Id;
            var timeZoneName = timeZone.StandardName;
            var time = _timeService.GetTime(timeZone);
            var payDay = _payDayService.GetSelectedPayDay();
            var payDayString = _payDayService.IsPayDay(time, payDay) ? "YES!!1!" : "No =(";
            var country = _countryService.GetCountry();
            var countryId = country.Id;
            var countryName = country.Name;
            var showCountryForm = activeForm == CountryFormName;
            var countryItems = GetCountryItems();
            var showTimeZoneForm = activeForm == TimeZoneFormName;
            var timeZoneItems = GetTimezoneItems();
            var showPayDayForm = activeForm == PayDayFormName;
            var payDayItems = GetPayDayItems();
            var localTime = time.ToString("R");
            var googleAnalyticsModel = _googleAnalyticsModelFactory.Create();
            
            return new IndexPageModel
                {
                    PayDayString = payDayString,
                    PayDay = payDay,
                    TimeZoneId = timeZoneId,
                    TimeZoneName = timeZoneName,
                    ShowCountryForm = showCountryForm,
                    ShowTimeZoneForm = showTimeZoneForm,
                    ShowPayDayForm = showPayDayForm,
                    CountryId = countryId,
                    CountryName = countryName,
                    LocalTime = localTime,
                    CountryItems = countryItems,
                    TimeZoneItems = timeZoneItems,
                    PayDayItems = payDayItems,
                    GoogleAnalyticsModel = googleAnalyticsModel
                };
        }

        private List<SelectListItem> GetPayDayItems()
        {
            var items = new List<SelectListItem>();
            for (var i = 1; i <= 31; i++)
            {
                var t = i.ToString(CultureInfo.InvariantCulture);
                var item = new SelectListItem {Text = t, Value = t};
                items.Add(item);
            }
            return items;
        }

        private List<SelectListItem> GetTimezoneItems()
        {
            var timezones = _timeService.GetTimezones();
            return timezones.Select(t => new SelectListItem { Text = t.DisplayName, Value = t.Id }).ToList();
        }

        private List<SelectListItem> GetCountryItems()
        {
            var countries = _countryService.GetCountries();
            return countries.Select(c => new SelectListItem { Text = c.Name, Value = c.Id }).ToList();
        }
    }
}