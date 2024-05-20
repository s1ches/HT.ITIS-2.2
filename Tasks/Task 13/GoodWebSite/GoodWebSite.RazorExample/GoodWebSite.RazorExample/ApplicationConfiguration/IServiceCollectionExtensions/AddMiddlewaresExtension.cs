using GoodWebSite.RazorExample.Middlewares;

namespace GoodWebSite.RazorExample.ApplicationConfiguration.IServiceCollectionExtensions;

public static class AddMiddlewaresExtension
{
    public static IServiceCollection AddMiddlewares(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<HttpErrorMiddleware>();
        return services.AddSingleton<AuthMiddlewareHelper>(sp =>
            new AuthMiddlewareHelper(configuration["JWT:CookieName"]!));
    }
}