using Models;
// using DbRepos;
using Services;
using Configuration;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// global cors policy
builder.Services.AddCors();




// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
 
 app.UseSwagger();
 app.UseSwaggerUI();


app.UseHttpsRedirection();
app.MapControllers();
app.Run();

