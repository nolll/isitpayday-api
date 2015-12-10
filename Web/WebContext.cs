using System;
using System.Web;

namespace Web
{
    public static class WebContext
    {
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
            return cookie == null ? null : cookie.Value;
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

        private static HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        private static HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }
    }
}