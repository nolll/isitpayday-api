using Plumbing;

namespace Web.Plumbing
{
    public class Bootstrapper
    {
        public UseCaseContainer UseCases { get; private set; }

        public Bootstrapper()
        {
            UseCases = new UseCaseContainer(new Dependencies(new CookieStorage()));
        }
    }
}