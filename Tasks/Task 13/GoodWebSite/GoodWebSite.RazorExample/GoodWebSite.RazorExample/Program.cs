using GoodWebSite.RazorExample.ApplicationConfiguration.IServiceCollectionExtensions;
using GoodWebSite.RazorExample.DAL;
using GoodWebSite.RazorExample.Interfaces;
using GoodWebSite.RazorExample.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(opt =>
    opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuth(configuration);

builder.Services.AddServices();
builder.Services.AddMiddlewares(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<HttpErrorMiddleware>();
app.UseMiddleware<AuthMiddlewareHelper>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/");

app.Run();