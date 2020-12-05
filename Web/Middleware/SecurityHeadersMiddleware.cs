using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Web.Extensions;
using Web.Services;
using Web.Settings;

namespace Web.Middleware
{
    [UsedImplicitly]
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        [UsedImplicitly]
        public async Task InvokeAsync(HttpContext httpContext, INonceProvider nonceProvider)
        {
            SetDefaultSecurityHeaders(httpContext);
            SetCspSecurityHeaders(httpContext, nonceProvider);
            await _next(httpContext);
        }

        private static void SetDefaultSecurityHeaders(HttpContext httpContext)
        {
            httpContext.AddHeader("X-Content-Type-Options", "nosniff");
            //httpContext.AddHeader("X-DNS-Prefetch-Control", "off");
            //httpContext.AddHeader("X-Download-Options", "noopen");
            httpContext.AddHeader("X-Frame-Options", "DENY");
            httpContext.AddHeader("X-XSS-Protection", "1; mode=block");
            httpContext.AddHeader("Strict-Transport-Security", "max-age=63072000; includeSubDomains");
        }

        private static void SetCspSecurityHeaders(HttpContext httpContext, INonceProvider nonceProvider)
        {
            var csp = GetCsp(nonceProvider);
            httpContext.AddHeader("Content-Security-Policy", csp);
        }

        private static string GetCsp(INonceProvider nonceProvider)
        {
            return string.Join("; ", GetDefaultCspValues(nonceProvider));
        }

        private static IEnumerable<string> GetDefaultCspValues(INonceProvider nonceProvider)
        {
            var gaNonce = nonceProvider.GetGaNonce();

            return new List<string>
            {
                "default-src 'self'",
                $"script-src 'self' *.google-analytics.com 'sha256-{GaScriptService.ComputedSha256Hash}' 'nonce-{gaNonce}'",
                "img-src 'self' *.google-analytics.com",
                "connect-src 'self' *.google-analytics.com",
            };
        }
    }
}