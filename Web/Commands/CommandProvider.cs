using Core.UseCases;
using Web.Models;

namespace Web.Commands
{
    public class CommandProvider : ICommandProvider
    {
        private readonly ISaveSettings _saveSettings;

        public CommandProvider(
            ISaveSettings saveSettings)
        {
            _saveSettings = saveSettings;
        }

        public SaveSettingsCommand GetSaveSettingsCommand(SettingsPostModel postModel)
        {
            return new SaveSettingsCommand(_saveSettings, postModel);
        }
    }
}