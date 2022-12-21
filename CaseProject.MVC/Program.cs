using CaseProject.Business.Abstract;
using CaseProject.Business.Concrete;
using CaseProject.Core.DataAccess.Dapper.Context;
using CaseProject.Data.Abstract;
using CaseProject.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ConfigurationManager configuration = builder.Configuration;
var databaseSetting = new DatabaseSettings();
configuration.Bind(nameof(DatabaseSettings), databaseSetting);
builder.Services.AddSingleton(databaseSetting);

builder.Services.AddSingleton<ICategoryDal, CategoryDal>();
builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<IProductDal, ProductDal>();
builder.Services.AddSingleton<IProductService, ProductManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
