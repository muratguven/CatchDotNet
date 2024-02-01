using CatchDotNet.CustomerService.Api;
using CatchDotNet.Core;
using Microsoft.EntityFrameworkCore;
using Carter;
using FluentValidation;
using Serilog;
using Serilog.Events;
using System.Reflection;
using Serilog.Formatting.Json;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var applicationName = Assembly.GetExecutingAssembly().GetName().Name;
// Log configurations
var test = builder.Configuration["ElasticSearch:Url"];
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("System", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", $"{applicationName} - {environment}")
    .Enrich.WithProperty("Developed By", "Murat Güven")
    .WriteTo.Console(new JsonFormatter())
    .WriteTo.Async(writeTo => writeTo.Debug(new RenderedCompactJsonFormatter()))
    .WriteTo.File("Logs/appLog-.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    .WriteTo.Async(writeTo => writeTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration["ElasticSearch:Url"]))
    {
        TypeName = null,
        AutoRegisterTemplate = true,
        IndexFormat = $"{applicationName.ToLower()}-{DateTime.UtcNow:yyyy-MM}",
        BatchAction = ElasticOpType.Create,
        CustomFormatter = new ElasticsearchJsonFormatter(),
        OverwriteTemplate = true,
        DetectElasticsearchVersion = true,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
        NumberOfReplicas = 1,
        NumberOfShards = 2,
        FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                                           EmitEventFailureHandling.WriteToFailureSink |
                                                           EmitEventFailureHandling.RaiseCallback |
                                                           EmitEventFailureHandling.ThrowException
    }))
    .CreateLogger();

//Serilog Config
builder.Host.UseSerilog();

// Database
builder.Services.AddAppEfCoreModule<CustomerDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
// app repositories
builder.Services.AddEfCore();

// config mediatr 
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//Fluent Validation Config
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// fast-endpoints for vertical slices
builder.Services.AddFastEndpoints().AddSwaggerGen();


//Carter 

//builder.Services.AddCarter();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.UseFastEndpoints();

app.UseSerilogRequestLogging();

//app.MapCarter();

app.Run();
