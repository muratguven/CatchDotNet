using CatchDotNet.CustomerService.Api;
using CatchDotNet.Core;
using Microsoft.EntityFrameworkCore;
using FastEndpoints;
using Carter;
using FluentValidation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Serilog Config
builder.Host.UseSerilog((context, configuration) => 
configuration.ReadFrom.Configuration(context.Configuration));

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
//builder.Services.AddFastEndpoints().AddSwaggerGen();


//Carter 

builder.Services.AddCarter();



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

//app.UseFastEndpoints();

app.UseSerilogRequestLogging();

app.MapCarter();

app.Run();
