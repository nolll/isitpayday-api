using System.Globalization;
using Core.Storage;

namespace Web
{
    public class CookieStorage : IStorage
    {
        public void SetPayDay(int payDay)
        {
            WebContext.SetCookie(CookieNames.PayDay, payDay.ToString(CultureInfo.InvariantCulture));
        }

        public void SetCountry(string countryId)
        {
            WebContext.SetCookie(CookieNames.Country, countryId);
        }

        public void SetTimeZone(string timeZone)
        {
            WebContext.SetCookie(CookieNames.TimeZone, timeZone);
        }
    }
}