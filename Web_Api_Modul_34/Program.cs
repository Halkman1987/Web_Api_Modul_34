using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Web_Api_Modul_34;
using Web_Api_Modul_34.Model;

var assembly = Assembly.GetAssembly(typeof(MappingProfile));

IConfiguration configuration;//Добавленна переменная

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(assembly);

configuration = builder.Configuration.AddJsonFile("HomeOptions.json").Build(); // доюаление конфигурации
builder.Services.Configure<HomeOptions>(configuration);                        // добавление сервиса

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
