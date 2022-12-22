using CaseProject.Business.Abstract;
using CaseProject.Business.Concrete;
using CaseProject.Core.DataAccess.Dapper.Context;
using CaseProject.Core.Utilities.Security.JWT;
using CaseProject.Data.Abstract;
using CaseProject.Data.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ConfigurationManager configuration = builder.Configuration;
var databaseSetting = new DatabaseSettings();
configuration.Bind(nameof(DatabaseSettings), databaseSetting);
builder.Services.AddSingleton(databaseSetting);

builder.Services.AddSingleton<ICategoryDal, CategoryDal>();
builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<IProductDal, ProductDal>();
builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<IAuthService, AuthManager>();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<ITokenHelper, JwtHelper>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
