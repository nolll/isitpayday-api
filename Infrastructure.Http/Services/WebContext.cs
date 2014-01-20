using System;
using System.Web;
using Core.Services;

namespace Infrastructure.Http.Services
{
    public class WebContext : IWebContext
    {
        private readonly ITimeService _timeService;

        public WebContext(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public string GetCookie(string name)
        {
            var cookie = Request.Cookies.Get(name);
            return cookie == null ? null : cookie.Value;
        }

        public void SetCookie(string name, string value)
        {
            var cookie = new HttpCookie(name)
                {
                    Value = value,
                    Expires = _timeService.GetTime().Add(TimeSpan.FromDays(3650))
                };
            Response.Cookies.Add(cookie);
        }

        public bool IsInProduction
        {
            get
            {
                return !GetHost().EndsWith("lan");
            }
        }

        private string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        private HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        private HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }
    }
}