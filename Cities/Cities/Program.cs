using Models;
using Services;
using Configuration;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var _services = new Service();
app.MapGet("/weatherforecast", () =>
{
    return _services.WeeklyMethod();
})
.WithOpenApi();

app.MapGet("/biweatherforecast", () =>
{
    return _services.BiWeeklyMethod();
})
.WithOpenApi();

app.Run();




