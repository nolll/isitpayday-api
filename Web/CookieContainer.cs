namespace Web
{
    public static class CookieContainer
    {
        public static int? PayDay => GetIntValue(WebContext.GetCookie(CookieNames.PayDay));
        public static string CountryCode => WebContext.GetCookie(CookieNames.Country);
        public static string TimezoneId => WebContext.GetCookie(CookieNames.TimeZone);
        public static int? PayDayType => GetIntValue(WebContext.GetCookie(CookieNames.PayDayType));

        private static int? GetIntValue(string value)
        {
            int intVal;
            if (value != null && int.TryParse(value, out intVal))
                return intVal;
            return null;
        }
    }
}