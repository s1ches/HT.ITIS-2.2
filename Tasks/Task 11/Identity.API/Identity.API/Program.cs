using Identity.API.Configurations;
using Identity.API.DAL;
using Identity.API.Interfaces;
using Identity.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ITemplateMessageBuilder, TemplateMessageBuilder>();

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity();
// Конфигурация аутентификации
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = IdentityConstants.ApplicationScheme;
    opt.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    opt.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
});

// Конфигурация кук
builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Identity.Cookie";
    config.LoginPath = "/Auth/Login";
    config.ReturnUrlParameter = "/";
    config.LogoutPath = "/Auth/Logout";
});

builder.Services.AddDistributedMemoryCache(opt =>
{
    opt.Clock = new SystemClock();
    opt.ExpirationScanFrequency = TimeSpan.FromHours(2); // Частота сканирования для проверки просроченных записей
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();