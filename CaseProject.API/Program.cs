using CaseProject.Core.DataAccess.Dapper.Context;
using CaseProject.Data.Abstract;
using CaseProject.Data.Concrete;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;
var databaseSetting = new DatabaseSettings();
configuration.Bind(nameof(DatabaseSettings), databaseSetting);
builder.Services.AddSingleton(databaseSetting);

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
