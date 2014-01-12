using System.Collections.Generic;
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

        public PageBuilder(
            IPayDayService payDayService,
            ITimeService timeService,
            ICountryService countryService)
        {
            _payDayService = payDayService;
            _timeService = timeService;
            _countryService = countryService;
        }

        public IndexPageModel Build(string activeForm)
        {
            var payDayString = _payDayService.IsPayDay ? "YES!!1!" : "No =(";
            var countryId = "SE";
            var countryName = "Sweden";
            var timeZone = "W. Europe Standard Time";
            var payDay = _payDayService.GetPayDay();
            var showCountryForm = activeForm == CountryFormName;
            var countryItems = GetCountryItems();
            var showTimeZoneForm = activeForm == TimeZoneFormName;
            var timeZoneItems = GetTimezoneItems();
            var showPayDayForm = activeForm == PayDayFormName;
            var payDayItems = GetPayDayItems();
            
            return new IndexPageModel
                {
                    PayDayString = payDayString,
                    PayDay = payDay,
                    TimeZone = timeZone,
                    ShowCountryForm = showCountryForm,
                    ShowTimeZoneForm = showTimeZoneForm,
                    PayDayItems = payDayItems,
                    TimeZoneItems = timeZoneItems,
                    ShowPayDayForm = showPayDayForm,
                    CountryId = countryId,
                    CountryName = countryName,
                    CountryItems = countryItems
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
}