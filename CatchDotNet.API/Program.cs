using CatchDotNet.API.ApplicationServices.Customers;
using CatchDotNet.API.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CatchDotNet.Core;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppEfCoreModule<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
       
});
builder.Services.AddEfCoreLayer();
builder.Services.AddAutoMapper(typeof(Program));
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
