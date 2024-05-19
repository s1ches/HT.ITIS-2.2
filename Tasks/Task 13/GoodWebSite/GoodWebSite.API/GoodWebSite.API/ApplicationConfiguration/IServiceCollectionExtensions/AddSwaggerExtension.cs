namespace GoodWebSite.ApplicationConfiguration.IServiceCollectionExtensions;

public static class AddSwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSwaggerGen(
        //     opt =>
        // {
        //     opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //     {
        //         Name = configuration["JWT:CookieName"],
        //         Type = SecuritySchemeType.Http,
        //         Scheme = "Bearer",
        //         BearerFormat = "JWT",
        //         In = ParameterLocation.Cookie,
        //         Description = "Authorization token"
        //     });
        //
        //     opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        //     {
        //         {
        //             new OpenApiSecurityScheme
        //             {
        //                 Reference = new OpenApiReference
        //                 {
        //                     Type = ReferenceType.SecurityScheme,
        //                     Id = "Bearer"
        //                 }
        //             },
        //             Array.Empty<string>()
        //         }
        //     });
        // }
        );
    }
}