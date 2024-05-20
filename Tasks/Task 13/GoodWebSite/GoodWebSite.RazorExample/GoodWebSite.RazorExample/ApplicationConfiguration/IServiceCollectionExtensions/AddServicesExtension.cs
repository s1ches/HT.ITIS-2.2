using GoodWebSite.RazorExample.DAL.Entities;
using GoodWebSite.RazorExample.Interfaces;
using GoodWebSite.RazorExample.Services;
using Microsoft.AspNetCore.Identity;

namespace GoodWebSite.RazorExample.ApplicationConfiguration.IServiceCollectionExtensions;

public static class AddServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();
        services.AddScoped<IUserClaimsManager, UserClaimsManager>();
        return services.AddScoped<ISignInManager, SignInManager>();
    }
}