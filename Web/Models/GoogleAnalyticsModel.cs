using Web.Services;

namespace Web.Models
{
    public class GoogleAnalyticsModel
    {
        public string Code { get; }
        public string Script { get; }
        public string Nonce { get; }
        public bool Enabled { get; }

        public GoogleAnalyticsModel(bool enabled, INonceProvider nonceProvider)
            :this(enabled, nonceProvider.GetGaNonce())
        {
        }

        public GoogleAnalyticsModel(bool enabled, string nonce)
        {
            Code = GaScriptService.Code;
            Script = GaScriptService.ScriptTag;
            Nonce = nonce;
            Enabled = enabled;
        }
    }
}