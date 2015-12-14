using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        public string PayDay { get; }
        public string FrequencyName { get; }
        public int FrequencyId { get; }
        public string TimeZoneId { get; }
        public string CountryId { get; }
        public string CountryName { get; }
        public string TimeZoneName { get; }
        public bool ShowCountryForm { get; }
        public IList<CustomSelectListItem> PayDayItems { get; }
        public bool ShowTimeZoneForm { get; }
        public IList<CustomSelectListItem> TimeZoneItems { get; }
        public bool ShowPayDayForm { get; }
        public IList<CustomSelectListItem> CountryItems { get; }
        public bool ShowFrequencyForm { get; }
        public IList<CustomSelectListItem> FrequencyItems { get; }

        public SettingsFormModel(
            ShowSettings.Result showSettingsResult,
            string activeForm)
        {
            PayDay = showSettingsResult.Frequency == Frequency.Monthly ? new NthFormatter(showSettingsResult.PayDay).Format() : ((Weekday)showSettingsResult.PayDay).ToString();
            FrequencyName = GetFrequencyText(showSettingsResult.Frequency);
            FrequencyId = (int)showSettingsResult.Frequency;
            TimeZoneId = showSettingsResult.TimeZone.Id;
            CountryId = showSettingsResult.Country.Id;
            CountryName = showSettingsResult.Country.Name;
            TimeZoneName = showSettingsResult.TimeZone.StandardName;
            ShowCountryForm = activeForm == CountryFormName;
            PayDayItems = GetPayDayItems(showSettingsResult);
            ShowTimeZoneForm = activeForm == TimeZoneFormName;
            TimeZoneItems = GetTimezoneItems(showSettingsResult.TimeZoneOptions);
            ShowPayDayForm = activeForm == PayDayFormName;
            CountryItems = GetCountryItems(showSettingsResult.CountryOptions);
            ShowFrequencyForm = activeForm == FrequencyFormName;
            FrequencyItems = GetFrequencyItems(showSettingsResult.FrequencyOptions);
        }

        private IList<CustomSelectListItem> GetPayDayItems(ShowSettings.Result showSettingsResult)
        {
            if(showSettingsResult.Frequency == Frequency.Weekly)
                return showSettingsResult.WeeklyPayDayOptions.Select(o => new CustomSelectListItem(o.ToString(), (int)o)).ToList();
            return showSettingsResult.MonthlyPayDayOptions.Select(o => new CustomSelectListItem(new NthFormatter(o).Format(), o)).ToList();
        }

        private List<CustomSelectListItem> GetFrequencyItems(IList<Frequency> frequencies)
        {
            return frequencies.Select(c => new CustomSelectListItem(GetFrequencyText(c), GetDropDownValue(c))).ToList();
        }

        private string GetFrequencyText(Frequency frequency)
        {
            return frequency == Frequency.Weekly ? "Weekly" : "Monthly";
        }

        private string GetDropDownValue(Frequency frequency)
        {
            return ((int)frequency).ToString(CultureInfo.InvariantCulture);
        }

        private List<CustomSelectListItem> GetTimezoneItems(IEnumerable<TimeZoneInfo> timeZones)
        {
            return timeZones.Select(t => new CustomSelectListItem(t.DisplayName, t.Id)).ToList();
        }

        private List<CustomSelectListItem> GetCountryItems(IEnumerable<Country> countries)
        {
            return countries.Select(c => new CustomSelectListItem(c.Name, c.Id)).ToList();
        }
    }
}