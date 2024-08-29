using CatchDotNet.Core.Yarp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yarp.ReverseProxy.Swagger;
using Yarp.ReverseProxy.Swagger.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

// Yarp configuration file
builder.Configuration.AddJsonFile("route.json");

//Adding yarp service
var test = builder.Configuration.GetSection("ReverseProxy");
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddSwagger(builder.Configuration.GetSection("ReverseProxy"));


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var config = app.Services.GetRequiredService<IOptionsMonitor<ReverseProxyDocumentFilterConfig>>().CurrentValue;
        foreach (var cluster in config.Clusters)
        {
            options.SwaggerEndpoint($"/swagger/{cluster.Key}/swagger.json", cluster.Key);
        }
    });
}

app.UseHttpsRedirection();
app.MapReverseProxy();

app.Run();


