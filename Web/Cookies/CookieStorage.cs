using System.Globalization;
using Core.Storage;

namespace Web.Cookies
{
    public class CookieStorage : IStorage
    {
        public void SetPayDay(int payDay)
        {
            WebContext.SetCookie(CookieNames.PayDay, payDay.ToString(CultureInfo.InvariantCulture));
        }

        public void SetFrequency(int frequency)
        {
            WebContext.SetCookie(CookieNames.Frequency, frequency.ToString(CultureInfo.InvariantCulture));
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