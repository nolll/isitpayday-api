﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;
using Web.Services;

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
            var time = _timeService.GetTime(timeZone);
            var payDayString = _payDayService.IsPayDay(time) ? "YES!!1!" : "No =(";
            var payDay = _payDayService.GetPayDay();
            var country = _countryService.GetCountry();
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
                    TimeZoneId = timeZone.Id,
                    TimeZoneName = timeZone.StandardName,
                    ShowCountryForm = showCountryForm,
                    ShowTimeZoneForm = showTimeZoneForm,
                    PayDayItems = payDayItems,
                    TimeZoneItems = timeZoneItems,
                    ShowPayDayForm = showPayDayForm,
                    CountryId = country.Id,
                    CountryName = country.Name,
                    CountryItems = countryItems,
                    LocalTime = localTime,
                    GoogleAnalyticsModel = googleAnalyticsModel
                };
        }

        private List<SelectListItem> GetPayDayItems()
        {
            var items = new List<SelectListItem>();
            for (var i = 1; i <= 31; i++)
            {
                var item = new SelectListItem {Text = i.ToString(), Value = i.ToString()};
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

    public interface IGoogleAnalyticsModelFactory
    {
        GoogleAnalyticsModel Create();
    }

    public class GoogleAnalyticsModelFactory : IGoogleAnalyticsModelFactory
    {
        private readonly IWebContext _webContext;

        public GoogleAnalyticsModelFactory(IWebContext webContext)
        {
            _webContext = webContext;
        }

        public GoogleAnalyticsModel Create()
        {
            return new GoogleAnalyticsModel
                {
                    Enabled = _webContext.IsInProduction,
                    Code = "UA-8453410-4"
                };
        }
    }
}