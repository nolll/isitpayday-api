using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Extensions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace Api.Middleware;

[UsedImplicitly]
public class SecurityHeadersMiddleware(RequestDelegate next)
{
    [UsedImplicitly]
    public async Task InvokeAsync(HttpContext httpContext)
    {
        SetDefaultSecurityHeaders(httpContext);
        SetCspSecurityHeaders(httpContext);
        await next(httpContext);
    }

    private static void SetDefaultSecurityHeaders(HttpContext httpContext)
    {
        httpContext.AddHeader("X-Content-Type-Options", "nosniff");
        httpContext.AddHeader("X-Frame-Options", "DENY");
        httpContext.AddHeader("X-XSS-Protection", "1; mode=block");
        httpContext.AddHeader("Strict-Transport-Security", "max-age=63072000; includeSubDomains");
        httpContext.AddHeader("Access-Control-Allow-Origin", "*");
    }

    private static void SetCspSecurityHeaders(HttpContext httpContext) => 
        httpContext.AddHeader("Content-Security-Policy", Csp);

    private static string Csp => string.Join("; ", DefaultCspValues);

    private static IEnumerable<string> DefaultCspValues => new List<string>
    {
        "default-src 'self'",
        "script-src 'self'"
    };
}