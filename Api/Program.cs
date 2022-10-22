using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    var strPort = System.Environment.GetEnvironmentVariable("PORT");
    if(!string.IsNullOrEmpty(strPort))
    {
        var port = int.Parse(strPort);
        options.ListenAnyIP(port);
    }
});

var app = builder.Build();