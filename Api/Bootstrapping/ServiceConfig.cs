using System;
using System.IO;
using System.Reflection;
using Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Api.Bootstrapping;

public class ServiceConfig
{
    private readonly AppSettings _settings;
    private readonly IServiceCollection _services;

    public ServiceConfig(AppSettings settings, IServiceCollection services)
    {
        _settings = settings;
        _services = services;
    }

    public void Configure()
    {
        AddCompression();
        AddLogging();
        AddDependencies();
        AddMvc();
        AddSwagger();
    }

    private void AddCompression()
    {
        _services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
        });
    }

    private void AddLogging()
    {
        _services.AddLogging(logging =>
        {
            if (_settings.Logging.Loggers.Debug)
                logging.AddDebug();

            if (_settings.Logging.Loggers.Console)
                logging.AddConsole();

            logging.SetMinimumLevel(_settings.Logging.LogLevel);
        });
    }

    private void AddDependencies()
    {
        _services.AddSingleton(_settings);
    }

    private void AddMvc()
    {
        _services.AddMvc(options =>
        {
            options.EnableEndpointRouting = false;
        });
    }

    private void AddSwagger()
    {
        _services.AddSwaggerGen(c =>
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var xmlFile = $"{assemblyName}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "IsItPayday Api", Version = "v1" });
            c.IncludeXmlComments(xmlPath);
        });
    }
}