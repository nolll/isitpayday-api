using Core.Services;
using Core.Storage;

namespace Infrastructure.Http.Storage
{
    public class CookieStorage : IStorage
    {
        private const string PayDayCookie = "payday";
        private const string CountryCookie = "country";
        private const string TimeZoneCookie = "timezone";

        private readonly IWebContext _webContext;

        public CookieStorage(
            IWebContext webContext)
        {
            _webContext = webContext;
        }

        public int? GetPayDay()
        {
            var value = _webContext.GetCookie(PayDayCookie);
            int payday;
            if (value != null && int.TryParse(value, out payday))
            {
                return payday;
            }
            return null;
        }

        public void SetPayDay(int payDay)
        {
            _webContext.SetCookie(PayDayCookie, payDay.ToString());
        }

        public string GetCountry()
        {
            return _webContext.GetCookie(CountryCookie);
        }

        public void SetCountry(string countryId)
        {
            _webContext.SetCookie(CountryCookie, countryId);
        }

        public string GetTimeZone()
        {
            return _webContext.GetCookie(TimeZoneCookie);
        }

        public void SetTimeZone(string timeZone)
        {
            _webContext.SetCookie(TimeZoneCookie, timeZone);
        }
    }
}