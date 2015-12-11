using Core.UseCases;
using Plumbing;

namespace Web.Plumbing
{
    public class UseCaseContainer
    {
        private readonly Dependencies _deps;

        public UseCaseContainer(Dependencies deps)
        {
            _deps = deps;
        }

        public ShowPayDay ShowPayDay { get { return new ShowPayDay(); } }
        public ShowSettings ShowSettings { get { return new ShowSettings(_deps.UserSettingsService); } }
        public SaveSettings SaveSettings { get { return new SaveSettings(_deps.Storage); } }
    }
}