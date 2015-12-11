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

        public ShowPayDay ShowPayDay => new ShowPayDay(_deps.UserSettingsService);
        public ShowSettings ShowSettings => new ShowSettings(_deps.UserSettingsService);
        public SaveSettings SaveSettings => new SaveSettings(_deps.Storage);
    }
}