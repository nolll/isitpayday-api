using System.Collections.Generic;
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

        public PageBuilder(IPayDayService payDayService)
        {
            _payDayService = payDayService;
        }

        public IndexPageModel Build(string activeForm)
        {
            var payDayString = _payDayService.IsPayDay ? "YES!!1!" : "No =(";
            var payDay = _payDayService.GetPayDay();
            var showCountryForm = activeForm == CountryFormName;
            var payDayItems = GetPayDayItems(payDay);
            var showTimeZoneForm = activeForm == TimeZoneFormName;
            var showPayDayForm = activeForm == PayDayFormName;

            return new IndexPageModel
                {
                    PayDayString = payDayString,
                    PayDay = payDay,
                    ShowCountryForm = showCountryForm,
                    ShowTimeZoneForm = showTimeZoneForm,
                    PayDayItems = payDayItems,
                    ShowPayDayForm = showPayDayForm
                };
        }

        private List<SelectListItem> GetPayDayItems(int payDay)
        {
            var items = new List<SelectListItem>();
            for (var i = 1; i <= 31; i++)
            {
                var item = new SelectListItem {Text = i.ToString(), Value = i.ToString()};
                items.Add(item);
            }
            return items;
        }
    }
}