using Core.UseCases.SaveSettings;
using Web.Models;

namespace Web.Commands
{
    public class SaveSettingsCommand : Command
    {
        private readonly ISaveSettingsInteractor _saveSettingsInteractor;
        private readonly SettingsModel _model;

        public SaveSettingsCommand(
            ISaveSettingsInteractor saveSettingsInteractor,
            SettingsModel model)
        {
            _saveSettingsInteractor = saveSettingsInteractor;
            _model = model;
        }

        public override bool Execute()
        {
            var request = new SaveSettingsRequest(
                _model.CountryId,
                _model.TimeZoneId,
                _model.PayDay);

            _saveSettingsInteractor.Execute(request);
            return true;
        }
    }
}