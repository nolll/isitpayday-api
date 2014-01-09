using System.Web;

namespace Web.Services
{
    public class WebContext : IWebContext
    {
        public string GetCookie(string name)
        {
            var cookie = Request.Cookies.Get(name);
            return cookie == null ? null : cookie.Value;
        }

        private HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }
    }
}