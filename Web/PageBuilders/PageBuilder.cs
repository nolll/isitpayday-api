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

        public PageBuilder(
            IPayDayService payDayService,
            ITimeService timeService)
        {
            _payDayService = payDayService;
            _timeService = timeService;
        }

        public IndexPageModel Build(string activeForm)
        {
            var payDayString = _payDayService.IsPayDay ? "YES!!1!" : "No =(";
            var payDay = _payDayService.GetPayDay();
            var timeZone = "UTC";
            var showCountryForm = activeForm == CountryFormName;
            var payDayItems = GetPayDayItems();
            var showTimeZoneForm = activeForm == TimeZoneFormName;
            var timeZoneItems = GetTimezoneItems();
            var showPayDayForm = activeForm == PayDayFormName;

            return new IndexPageModel
                {
                    PayDayString = payDayString,
                    PayDay = payDay,
                    TimeZone = timeZone,
                    ShowCountryForm = showCountryForm,
                    ShowTimeZoneForm = showTimeZoneForm,
                    PayDayItems = payDayItems,
                    TimeZoneItems = timeZoneItems,
                    ShowPayDayForm = showPayDayForm
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
    }
}