using System;
using System.IO;
using System.Reflection;
using Api.Middleware;
using Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT");
var settings = builder.Configuration.Get<AppSettings>() ?? new AppSettings();
var isDev = builder.Environment.IsDevelopment();
var isProd = isDev;

if (!string.IsNullOrEmpty(port))
    builder.WebHost.UseUrls("http://*:" + port);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddLogging(logging =>
{
    if (settings.Logging.Loggers.Debug)
        logging.AddDebug();

    if (settings.Logging.Loggers.Console)
        logging.AddConsole();

    logging.SetMinimumLevel(settings.Logging.LogLevel);
});

builder.Services.AddSingleton(settings);

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

builder.Services.AddSwaggerGen(c =>
{
    var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
    var xmlFile = $"{assemblyName}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IsItPayday Api", Version = "v1" });
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseResponseCompression();

if (isDev)
    app.UseDeveloperExceptionPage();

if (isProd)
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

//if (isDev)
//{
//    var errorUrl = $"/{Routes.Error}";
//    app.UseStatusCodePagesWithReExecute(errorUrl);
//    app.UseExceptionHandler(errorUrl);
//    app.UseMiddleware<ExceptionLoggingMiddleware>();
//}

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1"); });

app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseMvc();
app.UseStaticFiles();

app.Run();
