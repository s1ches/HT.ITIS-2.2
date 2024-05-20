using GoodWebSite.Middlewares;

namespace GoodWebSite.ApplicationConfiguration.IServiceCollectionExtensions;

public static class AddMiddlewaresExtension
{
    public static IServiceCollection AddMiddlewares(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<AuthMiddlewareHelper>(sp =>
            new AuthMiddlewareHelper(configuration["JWT:CookieName"]!));
        return services.AddSingleton<ExceptionMiddleware>();
    }
}