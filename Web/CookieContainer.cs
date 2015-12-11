namespace Web
{
    public class CookieContainer
    {
        private const string PayDayCookie = "payday";
        private const string CountryCookie = "country";
        private const string TimeZoneCookie = "timezone";
        private const string PayDayTypeCookie = "paydaytype";

        public int? PayDay
        {
            get { return GetIntValue(WebContext.GetCookie(PayDayCookie)); }
        }

        public string CountryCode
        {
            get { return WebContext.GetCookie(CountryCookie); }
        }

        public string TimezoneId
        {
            get { return WebContext.GetCookie(TimeZoneCookie); }
        }

        public int? PayDayType
        {
            get { return GetIntValue(WebContext.GetCookie(PayDayTypeCookie)); }
        }

        private static int? GetIntValue(string value)
        {
            int intVal;
            if (value != null && int.TryParse(value, out intVal))
            {
                return intVal;
            }
            return null;
        }
    }
}