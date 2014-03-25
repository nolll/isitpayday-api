using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Models
{
    public class IndexPageModel : IndexPagePostModel, IPageModel
    {
        public string PayDayString { get; set; }
        public string CountryName { get; set; }
        public string TimeZoneName { get; set; }
        public bool ShowCountryForm { get; set; }
        public List<SelectListItem> PayDayItems { get; set; }
        public bool ShowTimeZoneForm { get; set; }
        public List<SelectListItem> TimeZoneItems { get; set; }
        public bool ShowPayDayForm { get; set; }
        public List<SelectListItem> CountryItems { get; set; }
        public List<SelectListItem> PayDayTypeItems { get; set; }
        public string LocalTime { get; set; }
        public GoogleAnalyticsModel GoogleAnalyticsModel { get; set; }
    }

    public class IndexPagePostModel
    {
        public int? PayDay { get; set; }
        public string TimeZoneId { get; set; }
        public string CountryId { get; set; }
    }
}