using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Models
{
    public class IndexPageModel
    {
        public string PayDayString { get; set; }
        public int PayDay { get; set; }
        public bool ShowCountryForm { get; set; }
        public List<SelectListItem> PayDayItems { get; set; }
        public bool ShowTimeZoneForm { get; set; }
        public bool ShowPayDayForm { get; set; }
    }
}