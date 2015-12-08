using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Core.Classes;
using Core.UseCases;
using Web.Models;

namespace Web.ModelFactories
{
    public class SettingsFormModelFactory : ISettingsFormModelFactory
    {
        private const string CountryFormName = "country";
        private const string TimeZoneFormName = "timezone";
        private const string PayDayFormName = "payday";
        
        private readonly IShowSettings _showSettings;

        public SettingsFormModelFactory(
            IShowSettings showSettings)
        {
            _showSettings = showSettings;
        }

        public SettingsFormModel Create(string activeForm)
        {
            var result = _showSettings.Execute();

            return new SettingsFormModel
            {
                PayDay = result.PayDay,
                TimeZoneId = result.TimeZone.Id,
                TimeZoneName = result.TimeZone.StandardName,
                ShowCountryForm = activeForm == CountryFormName,
                ShowTimeZoneForm = activeForm == TimeZoneFormName,
                ShowPayDayForm = activeForm == PayDayFormName,
                CountryId = result.Country.Id,
                CountryName = result.Country.Name,
                CountryItems = GetCountryItems(result.CountryOptions),
                TimeZoneItems = GetTimezoneItems(result.TimeZoneOptions),
                PayDayItems = GetPayDayItems(result.PayDayOptions),
                PayDayTypeItems = GetPayDayTypeItems(result.PayDayTypeOptions),
            };
        }

        private List<SelectListItem> GetPayDayItems(IEnumerable<int> daysInMonth)
        {
            return daysInMonth.Select(c => new SelectListItem { Text = c.ToString(CultureInfo.InvariantCulture), Value = c.ToString(CultureInfo.InvariantCulture) }).ToList();
        }

        private List<SelectListItem> GetPayDayTypeItems(IList<PayDayType> payDayTypes)
        {
            return payDayTypes.Select(c => new SelectListItem { Text = GetDropDownText(c), Value = GetDropDownValue(c) }).ToList();
        }

        private string GetDropDownText(PayDayType payDayType)
        {
            return payDayType == PayDayType.Weekly ? "Weekly" : "Monthly";
        }

        private string GetDropDownValue(PayDayType payDayType)
        {
            return ((int)payDayType).ToString(CultureInfo.InvariantCulture);
        }

        private List<SelectListItem> GetTimezoneItems(IEnumerable<TimeZoneInfo> timeZones)
        {
            return timeZones.Select(t => new SelectListItem { Text = t.DisplayName, Value = t.Id }).ToList();
        }

        private List<SelectListItem> GetCountryItems(IEnumerable<Country> countries)
        {
            return countries.Select(c => new SelectListItem { Text = c.Name, Value = c.Id }).ToList();
        }
    }
}