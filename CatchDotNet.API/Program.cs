using CatchDotNet.API.ApplicationService.Customers;
using CatchDotNet.API.EntityFrameworkCore;
using CatchDotNet.API.Infrastructure.Data;
using CatchDotNet.API.Infrastructure.DependencyInjection.Microsoft;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppEfCore<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    
});
builder.Services.AddEfCoreLayer();

// app dependencies
builder.Services.AddTransient(typeof(ICustomerAppService), typeof(CustomerAppService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();