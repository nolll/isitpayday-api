using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Core.Services;
using Core.UseCases.GetPayDay;
using Web.ModelFactories;
using Web.Models;

namespace Web.PageBuilders
{
    public class PageBuilder : IPageBuilder
    {
        private const string CountryFormName = "country";
        private const string TimeZoneFormName = "timezone";
        private const string PayDayFormName = "payday";

        private readonly ITimeService _timeService;
        private readonly ICountryService _countryService;
        private readonly IGoogleAnalyticsModelFactory _googleAnalyticsModelFactory;
        private readonly IUserSettingsService _userSettingsService;
        private readonly IShowPayDayInteractor _showPayDayInteractor;

        public PageBuilder(
            ITimeService timeService,
            ICountryService countryService,
            IGoogleAnalyticsModelFactory googleAnalyticsModelFactory,
            IUserSettingsService userSettingsService,
            IShowPayDayInteractor showPayDayInteractor)
        {
            _timeService = timeService;
            _countryService = countryService;
            _googleAnalyticsModelFactory = googleAnalyticsModelFactory;
            _userSettingsService = userSettingsService;
            _showPayDayInteractor = showPayDayInteractor;
        }

        public IndexPageModel Build(string activeForm)
        {
            var showPayDayResult = _showPayDayInteractor.Execute();
            var userSettings = _userSettingsService.GetSettings();
            var timeZone = userSettings.TimeZone;
            var timeZoneId = timeZone.Id;
            var timeZoneName = timeZone.StandardName;
            var usertime = _timeService.GetTime(timeZone);
            var payDay = userSettings.PayDay;
            var country = userSettings.Country;
            var countryId = country.Id;
            var countryName = country.Name;
            var showCountryForm = activeForm == CountryFormName;
            var countryItems = GetCountryItems();
            var showTimeZoneForm = activeForm == TimeZoneFormName;
            var timeZoneItems = GetTimezoneItems();
            var showPayDayForm = activeForm == PayDayFormName;
            var payDayItems = GetPayDayItems();
            var payDayTypeItems = GetPayDayTypeItems();
            var localTime = usertime.ToString("R");
            var googleAnalyticsModel = _googleAnalyticsModelFactory.Create();
            
            return new IndexPageModel
                {
                    PayDayString = showPayDayResult.Message,
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
                    PayDayTypeItems = payDayTypeItems,
                    GoogleAnalyticsModel = googleAnalyticsModel
                };
        }

        private List<SelectListItem> GetPayDayItems()
        {
            var items = new List<SelectListItem>();
            for (var i = 1; i <= 31; i++)
            {
                var t = i.ToString(CultureInfo.InvariantCulture);
                var item = new SelectListItem { Text = t, Value = t };
                items.Add(item);
            }
            return items;
        }

        private List<SelectListItem> GetPayDayTypeItems()
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Monthly", Value = "1" });
            items.Add(new SelectListItem { Text = "Weekly", Value = "2" });
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