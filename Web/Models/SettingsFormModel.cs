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
        private const string FrequencyFormName = "frequency";
        private const string PayDayFormName = "payday";

        public int? PayDay { get; }
        public string Frequency { get; }
        public string TimeZoneId { get; }
        public string CountryId { get; }
        public string CountryName { get; }
        public string TimeZoneName { get; }
        public bool ShowCountryForm { get; }
        public List<SelectListItem> PayDayItems { get; }
        public bool ShowTimeZoneForm { get; }
        public List<SelectListItem> TimeZoneItems { get; }
        public bool ShowPayDayForm { get; }
        public List<SelectListItem> CountryItems { get; }
        public bool ShowFrequencyForm { get; }
        public List<SelectListItem> FrequencyItems { get; }

        public SettingsFormModel(
            ShowSettings.Result showSettingsResult,
            string activeForm)
        {
            PayDay = showSettingsResult.PayDay;
            Frequency = GetFrequencyText(showSettingsResult.PayDayType);
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
            ShowFrequencyForm = activeForm == FrequencyFormName;
            FrequencyItems = GetFrequencyItems(showSettingsResult.FrequencyOptions);
        }

        private List<SelectListItem> GetPayDayItems(IEnumerable<int> daysInMonth)
        {
            return daysInMonth.Select(c => new SelectListItem { Text = c.ToString(CultureInfo.InvariantCulture), Value = c.ToString(CultureInfo.InvariantCulture) }).ToList();
        }

        private List<SelectListItem> GetFrequencyItems(IList<PayDayType> payDayTypes)
        {
            return payDayTypes.Select(c => new SelectListItem { Text = GetFrequencyText(c), Value = GetDropDownValue(c) }).ToList();
        }

        private string GetFrequencyText(PayDayType payDayType)
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