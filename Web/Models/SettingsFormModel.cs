using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Models
{
    public class SettingsFormModel : SettingsModel
    {
        public string CountryName { get; set; }
        public string TimeZoneName { get; set; }
        public bool ShowCountryForm { get; set; }
        public List<SelectListItem> PayDayItems { get; set; }
        public bool ShowTimeZoneForm { get; set; }
        public List<SelectListItem> TimeZoneItems { get; set; }
        public bool ShowPayDayForm { get; set; }
        public List<SelectListItem> CountryItems { get; set; }
        public List<SelectListItem> PayDayTypeItems { get; set; }
    }
}