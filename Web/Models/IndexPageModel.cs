using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Models
{
    public class IndexPageModel : IndexPagePostModel
    {
        public string PayDayString { get; set; }
        public string CountryName { get; set; }
        public bool ShowCountryForm { get; set; }
        public List<SelectListItem> PayDayItems { get; set; }
        public bool ShowTimeZoneForm { get; set; }
        public List<SelectListItem> TimeZoneItems { get; set; }
        public bool ShowPayDayForm { get; set; }
        public List<SelectListItem> CountryItems { get; set; }
    }

    public class IndexPagePostModel
    {
        public int? PayDay { get; set; }
        public string TimeZone { get; set; }
        public string CountryId { get; set; }
    }
}