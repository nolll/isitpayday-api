using Web.Models;
using Web.Storage;

namespace Web.Controllers
{
    public class SaveSettingsCommand : Command
    {
        private readonly IStorage _storage;
        private readonly IndexPagePostModel _model;

        public SaveSettingsCommand(
            IStorage storage,
            IndexPagePostModel model)
        {
            _storage = storage;
            _model = model;
        }

        public override bool Execute()
        {
            if (_model.CountryId != null)
            {
                _storage.SetCountry(_model.CountryId);
                return true;
            }
            if (_model.TimeZoneId != null)
            {
                _storage.SetTimeZone(_model.TimeZoneId);
                return true;
            }
            if (_model.PayDay.HasValue)
            {
                _storage.SetPayDay(_model.PayDay.Value);
                return true;
            }
            return false;
        }
    }
}