using System;
using System.Text;

namespace Web.Services
{
    public class NonceProvider : INonceProvider
    {
        private const string ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string _gaNonce = null;

        public string GetGaNonce() => _gaNonce ?? (_gaNonce = CreateNonce(16));

        private static string CreateNonce(int length)
        {
            var random = new Random();

            var nonceString = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                nonceString.Append(ValidChars[random.Next(0, ValidChars.Length - 1)]);
            }

            return nonceString.ToString();
        }
    }
}