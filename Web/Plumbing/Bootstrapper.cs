using Plumbing;
using Web.Cookies;

namespace Web.Plumbing
{
    public class Bootstrapper
    {
        public UseCaseContainer UseCases { get; }

        public Bootstrapper()
        {
            UseCases = new UseCaseContainer(new Dependencies(new CookieStorage()));
        }
    }
}