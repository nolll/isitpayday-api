using Core.UseCases.SaveSettings;
using Web.Models;

namespace Web.Commands
{
    public class SaveSettingsCommand : Command
    {
        private readonly ISaveSettingsInteractor _saveSettingsInteractor;
        private readonly IndexPagePostModel _model;

        public SaveSettingsCommand(
            ISaveSettingsInteractor saveSettingsInteractor,
            IndexPagePostModel model)
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