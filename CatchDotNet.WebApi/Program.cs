using Serilog.Events;
using Serilog;
using System.Reflection;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Formatting.Elasticsearch;
using FluentValidation;
using CatchDotNet.WebApi;
using CatchDotNet.Core.DependencyInjection.Microsoft;
using CatchDotNet.Core;
using CatchDotNet.Core.EndPoints;
using Microsoft.EntityFrameworkCore;
using CatchDotNet.Core.Exceptions;
using CatchDotNet.WebApi.EntityFrameworkCore;
using CatchDotNet.WebApi.Features.Cases.Domains;
using Microsoft.AspNetCore.Identity;
using CatchDotNet.WebApi.Features.Identity.Domains;
using Microsoft.OpenApi.Models;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

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
    .Enrich.WithProperty("Developed By", "Murat G�ven")
    .WriteTo.Console(new JsonFormatter())
    .WriteTo.Async(writeTo => writeTo.Debug(new RenderedCompactJsonFormatter()))
    .WriteTo.File("Logs/appLog-.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
    .WriteTo.Async(writeTo => writeTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration["ElasticSearch:Url"] ?? string.Empty))
    {
        TypeName = null,
        AutoRegisterTemplate = true,
        IndexFormat = $"{applicationName?.ToLower()}-{DateTime.UtcNow:yyyy-MM}",
        BatchAction = ElasticOpType.Create,
        CustomFormatter = new ElasticsearchJsonFormatter(),
        OverwriteTemplate = true,
        DetectElasticsearchVersion = true,
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
        NumberOfReplicas = 1,
        NumberOfShards = 2,
        FailureCallback = (e, f) =>
        {
            Console.WriteLine("Unable to submit event " + e.MessageTemplate);

        },
        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                                           EmitEventFailureHandling.WriteToFailureSink |
                                                           EmitEventFailureHandling.RaiseCallback |
                                                           EmitEventFailureHandling.ThrowException
    }))
    .CreateLogger();

//Serilog Config
builder.Host.UseSerilog();

// Database
builder.Services.AddAppEfCoreModule<CatchDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});


// config mediatr 
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//Fluent Validation Config
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

//Endpoint configurations
builder.Services.AddEndPoints(Assembly.GetExecutingAssembly());


// swagger configurations
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CatchDotNet API",
        Version = "v1",
        Description = "An example of Minimal API with Swagger documentation",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Elastic Search from CatchDotnet Core
builder.Services.AddElasticSearch(builder.Configuration);


builder.Services.AddCatchDotNetCore();

// Authentication and Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<CatchDbContext>()
    .AddApiEndpoints();

// Application Dependencies

builder.Services.AddEfCore();
// Dependecies Here!!!!!
builder.Services.AddTransient<ICustomerDetailKeyRepository, CustomerDetailKeyRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryEfCoreRepository>();


var app = builder.Build();

// app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API Example v1");
        c.RoutePrefix = "swagger"; 
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//My minimal api mapping here :)
app.MapEndPoints();

app.UseSerilogRequestLogging();

app.MapIdentityApi<User>();
app.UseHttpMetrics();
app.UseMiddleware<GlobalExceptionMiddleware>();


app.Run();
