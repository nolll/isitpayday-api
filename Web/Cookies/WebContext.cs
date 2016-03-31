using System;
using System.Web;

namespace Web.Cookies
{
    public static class WebContext
    {
        private static HttpRequest Request => HttpContext.Current.Request;
        private static HttpResponse Response => HttpContext.Current.Response;

        public static string Host
        {
            get
            {
                var url = Request.Url;
                return url.Host;
            }
        }

        public static string GetCookie(string name)
        {
            var cookie = Request.Cookies.Get(name);
            return cookie?.Value;
        }

        public static void SetCookie(string name, string value)
        {
            var cookie = new HttpCookie(name)
            {
                Value = value,
                Expires = DateTime.Now.Add(TimeSpan.FromDays(3650))
            };
            Response.Cookies.Add(cookie);
        }
    }
}