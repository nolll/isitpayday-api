using Plumbing;

namespace Web
{
    public class Bootstrapper
    {
        public UseCaseContainer UseCases { get; private set; }

        public Bootstrapper()
        {
            var deps = new Dependencies();
            UseCases = new UseCaseContainer(deps);
        }
    }
}