using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Core.Classes;
using Core.Services;
using Web.Models;

namespace Web.ModelFactories
{
    public class SettingsFormModelFactory : ISettingsFormModelFactory
    {
        private const string CountryFormName = "country";
        private const string TimeZoneFormName = "timezone";
        private const string PayDayFormName = "payday";
        
        private readonly ICountryService _countryService;
        private readonly ITimeService _timeService;
        
        public SettingsFormModelFactory(
            ICountryService countryService,
            ITimeService timeService)
        {
            _countryService = countryService;
            _timeService = timeService;
        }

        public SettingsFormModel Create(UserSettings userSettings, string activeForm)
        {
            var timeZone = userSettings.TimeZone;
            var timeZoneId = timeZone.Id;
            var timeZoneName = timeZone.StandardName;
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
            
            return new SettingsFormModel
                {
                    PayDay = payDay,
                    TimeZoneId = timeZoneId,
                    TimeZoneName = timeZoneName,
                    ShowCountryForm = showCountryForm,
                    ShowTimeZoneForm = showTimeZoneForm,
                    ShowPayDayForm = showPayDayForm,
                    CountryId = countryId,
                    CountryName = countryName,
                    CountryItems = countryItems,
                    TimeZoneItems = timeZoneItems,
                    PayDayItems = payDayItems,
                    PayDayTypeItems = payDayTypeItems,
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
            return new List<SelectListItem>
                {
                    new SelectListItem
                        {
                            Text = "Monthly",
                            Value = GetDropDownValue(PayDayType.Monthly)
                        },
                    new SelectListItem
                        {
                            Text = "Weekly",
                            Value = GetDropDownValue(PayDayType.Weekly)
                        }
                };
        }

        private string GetDropDownValue(PayDayType payDayType)
        {
            return ((int)payDayType).ToString(CultureInfo.InvariantCulture);
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