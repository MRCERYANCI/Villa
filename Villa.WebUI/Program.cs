using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection;
using Villa.BusniessLayer.Abstract;
using Villa.BusniessLayer.Concrete;
using Villa.DataAccessLayer.Abstract;
using Villa.DataAccessLayer.Context;
using Villa.DataAccessLayer.EntityFramework;
using Villa.DataAccessLayer.Repositories;
using Villa.EntityLayer.Entities;
using Villa.WebUI.Extensions;
using Villa.WebUI.Hubs;
using Villa.WebUI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddHttpClient();
builder.Services.AddServiceExtensions();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var mongoDataBase = new MongoClient(builder.Configuration.GetConnectionString("MongoConnection")).GetDatabase(builder.Configuration.GetSection("DatabaseName").Value);
builder.Services.AddDbContext<VillaContext>(opt =>
{
    opt.UseMongoDB(mongoDataBase.Client, mongoDataBase.DatabaseNamespace.DatabaseName);
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<VillaContext>().AddErrorDescriber<CustomerIdentityValidator>();

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();  //Tümj Proje Seviyesinde Login Ýle Giriþi Zorunlu Kýl
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));  //Bütün Contorllere authentication iþlemini koy Yani Giriþ Zorunluluðunu Koy
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromSeconds(30);
    options.LoginPath = "/Account/Login";
});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
//{
//    x.LoginPath = "/Account/Login";
//});




builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseCors("CorsPolicy");
app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//Sistemde Olduðumu Belirtiyoz
app.UseAuthorization();

app.MapHub<SignalRHub>("/signalrhub");  

//localhost:7016/signalrhub

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
