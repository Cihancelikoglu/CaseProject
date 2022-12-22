using CaseProject.Business.Abstract;
using CaseProject.Business.Concrete;
using CaseProject.Core.DataAccess.Dapper.Context;
using CaseProject.Core.Utilities.Helpers.FileHelper.Abstract;
using CaseProject.Core.Utilities.Helpers.FileHelper.Concrete;
using CaseProject.Core.Utilities.Security.Encryption;
using CaseProject.Core.Utilities.Security.JWT;
using CaseProject.Data.Abstract;
using CaseProject.Data.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddSingleton<IFileHelper, FileHelper>();


var tokenOptions = configuration.GetSection("TokenOptions").Get<CaseProject.Core.Utilities.Security.JWT.TokenOptions>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
