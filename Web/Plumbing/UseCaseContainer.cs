using Core.UseCases;

namespace Web.Plumbing
{
    public class UseCaseContainer
    {
        public ShowPayDay ShowPayDay => new ShowPayDay();
        public Options Options => new Options();
    }
}