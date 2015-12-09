using System.Web;

namespace Web.Controllers
{
    public class WebContext
    {
        private readonly string _host;

        public WebContext(HttpRequestBase request)
        {
            _host = GetHost(request);
        }

        public bool IsInProduction
        {
            get { return !_host.EndsWith("lan"); }
        }

        private string GetHost(HttpRequestBase request)
        {
            return request.Url != null ? request.Url.Host : "com";
        }
    }
}