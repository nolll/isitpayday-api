using System.Globalization;
using Core.Storage;

namespace Web
{
    public class CookieStorage : IStorage
    {
        private const string PayDayCookie = "payday";
        private const string CountryCookie = "country";
        private const string TimeZoneCookie = "timezone";
        private const string PayDayTypeCookie = "paydaytype";

        public int? GetPayDay()
        {
            return GetIntValue(WebContext.GetCookie(PayDayCookie));
        }

        public void SetPayDay(int payDay)
        {
            WebContext.SetCookie(PayDayCookie, payDay.ToString(CultureInfo.InvariantCulture));
        }

        public string GetCountry()
        {
            return WebContext.GetCookie(CountryCookie);
        }

        public void SetCountry(string countryId)
        {
            WebContext.SetCookie(CountryCookie, countryId);
        }

        public string GetTimeZone()
        {
            return WebContext.GetCookie(TimeZoneCookie);
        }

        public void SetTimeZone(string timeZone)
        {
            WebContext.SetCookie(TimeZoneCookie, timeZone);
        }

        public int? GetPayDayType()
        {
            return GetIntValue(WebContext.GetCookie(PayDayTypeCookie));
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