﻿namespace Web.Models
{
    public class SettingsPostModel
    {
        public int? PayDay { get; set; }
        public int? FrequencyId { get; set; }
        public string TimeZoneId { get; set; }
        public string CountryId { get; set; }
    }
}