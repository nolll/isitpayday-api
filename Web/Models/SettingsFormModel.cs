using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Core.Classes;
using Core.UseCases;

namespace Web.Models
{
    public class SettingsFormModel
    {
        private const string CountryFormName = "country";
        private const string TimeZoneFormName = "timezone";
        private const string PayDayFormName = "payday";

        public int? PayDay { get; private set; }
        public string TimeZoneId { get; private set; }
        public string CountryId { get; private set; }
        public string CountryName { get; private set; }
        public string TimeZoneName { get; private set; }
        public bool ShowCountryForm { get; private set; }
        public List<SelectListItem> PayDayItems { get; private set; }
        public bool ShowTimeZoneForm { get; private set; }
        public List<SelectListItem> TimeZoneItems { get; private set; }
        public bool ShowPayDayForm { get; private set; }
        public List<SelectListItem> CountryItems { get; private set; }
        public List<SelectListItem> PayDayTypeItems { get; private set; }

        public SettingsFormModel(
            ShowSettings.Result showSettingsResult,
            string activeForm)
        {
            PayDay = showSettingsResult.PayDay;
            TimeZoneId = showSettingsResult.TimeZone.Id;
            CountryId = showSettingsResult.Country.Id;
            CountryName = showSettingsResult.Country.Name;
            TimeZoneName = showSettingsResult.TimeZone.StandardName;
            ShowCountryForm = activeForm == CountryFormName;
            PayDayItems = GetPayDayItems(showSettingsResult.PayDayOptions);
            ShowTimeZoneForm = activeForm == TimeZoneFormName;
            TimeZoneItems = GetTimezoneItems(showSettingsResult.TimeZoneOptions);
            ShowPayDayForm = activeForm == PayDayFormName;
            CountryItems = GetCountryItems(showSettingsResult.CountryOptions);
            PayDayTypeItems = GetPayDayTypeItems(showSettingsResult.PayDayTypeOptions);
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