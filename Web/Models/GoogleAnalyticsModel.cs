using Web.Services;

namespace Web.Models
{
    public class GoogleAnalyticsModel
    {
        public string Code { get; }
        public string Script { get; }
        public bool IsEnabled { get; }

        public GoogleAnalyticsModel(bool isEnabled)
        {
            Code = GaScriptService.Code;
            Script = GaScriptService.ScriptTag;
            IsEnabled = isEnabled;
        }
    }
}