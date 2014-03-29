using Core.UseCases;
using Web.Models;

namespace Web.Commands
{
    public class SaveSettingsCommand : Command
    {
        private readonly ISaveSettings _saveSettings;
        private readonly SettingsModel _model;

        public SaveSettingsCommand(
            ISaveSettings saveSettings,
            SettingsModel model)
        {
            _saveSettings = saveSettings;
            _model = model;
        }

        public override bool Execute()
        {
            var request = new SaveSettingsRequest(
                _model.CountryId,
                _model.TimeZoneId,
                _model.PayDay);

            _saveSettings.Execute(request);
            return true;
        }
    }
}