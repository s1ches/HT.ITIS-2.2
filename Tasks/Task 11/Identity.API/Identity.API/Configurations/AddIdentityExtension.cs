using Identity.API.DAL;
using Identity.API.DAL.Entities;
using Identity.API.Services.IdentityServices;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Configurations;

public static class AddIdentityExtension
{
    private const string AllowedUserNameCharacters = 
        "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMйцукенгшщзхъфывапролджэячсмитьбюё ";

    public static IdentityBuilder AddIdentity(this IServiceCollection services)
    {
        return services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.User.AllowedUserNameCharacters = AllowedUserNameCharacters;
                opt.User.RequireUniqueEmail = true;
                opt.Tokens.EmailConfirmationTokenProvider = "EmailAndSmsTokenProvider";
                opt.Password.RequiredLength = 5;
            })
            .AddPasswordValidator<PasswordValidator>()
            .AddTokenProvider<TokenProvider<User>>("EmailAndSmsTokenProvider")
            .AddEntityFrameworkStores<AppDbContext>();
    }
}