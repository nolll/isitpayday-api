using System.Security.Cryptography;
using System.Text;

namespace Web.Services
{
    public static class GaScriptService
    {
        public const string Code = "UA-8453410-4";
        private static string Script => $"window.ga=window.ga||function(){{(ga.q=ga.q||[]).push(arguments)}};ga.l=+new Date;ga('create', '{Code}', 'auto');ga('send', 'pageview');";
        public static string ScriptTag => $"<script>{Script}</script>";
        public static string Sha256Hash => ComputeHash(Script);

        private static string ComputeHash(string s)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(s));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}