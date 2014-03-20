using Core.UseCases.SaveSettings;
using Web.Models;

namespace Web.Commands
{
    public class CommandProvider : ICommandProvider
    {
        private readonly ISaveSettingsInteractor _saveSettingsInteractor;

        public CommandProvider(
            ISaveSettingsInteractor saveSettingsInteractor)
        {
            _saveSettingsInteractor = saveSettingsInteractor;
        }

        public SaveSettingsCommand GetSaveSettingsCommand(IndexPagePostModel postModel)
        {
            return new SaveSettingsCommand(_saveSettingsInteractor, postModel);
        }
    }
}