﻿using System.Globalization;
using Core.Services;
using Core.Storage;

namespace Infrastructure.Http.Storage
{
    public class CookieStorage : IStorage
    {
        private const string PayDayCookie = "payday";
        private const string CountryCookie = "country";
        private const string TimeZoneCookie = "timezone";
        private const string PayDayTypeCookie = "paydaytype";

        private readonly IWebContext _webContext;

        public CookieStorage(
            IWebContext webContext)
        {
            _webContext = webContext;
        }

        public int? GetPayDay()
        {
            return GetIntValue(_webContext.GetCookie(PayDayCookie));
        }

        public void SetPayDay(int payDay)
        {
            _webContext.SetCookie(PayDayCookie, payDay.ToString(CultureInfo.InvariantCulture));
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

        public int? GetPayDayType()
        {
            return GetIntValue(_webContext.GetCookie(PayDayTypeCookie));
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