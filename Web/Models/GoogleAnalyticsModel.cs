using Web.Services;

namespace Web.Models
{
    public class GoogleAnalyticsModel
    {
        public string Code { get; }
        public string Script { get; }
        public bool Enabled { get; }

        public GoogleAnalyticsModel(bool enabled)
        {
            Code = GaScriptService.Code;
            Script = GaScriptService.ScriptTag;
            Enabled = enabled;
        }
    }
}