using GoodWebSite.Constants;
using GoodWebSite.DAL.Entities;
using GoodWebSite.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GoodWebSite.Services;

public class SignInManager(IPasswordHasher<User> passwordHasher,
    IHttpContextAccessor contextAccessor,
    IAuthTokenProvider authTokenProvider,
    IConfiguration configuration)
    : ISignInManager
{
    public bool TryPasswordSignIn(User user, string password, bool isPersistent)
    {
        var passwordVerificationResult = passwordHasher
            .VerifyHashedPassword(user, user.PasswordHash, password);

        if (passwordVerificationResult != PasswordVerificationResult.Success)
            return false;

        var accessToken = authTokenProvider.GenerateAccessToken(user);
        var cookieOptions = CookiesConfigOptions.BaseCookiesOptions;
        
        if(isPersistent)
            cookieOptions.Expires = DateTimeOffset.UtcNow.AddDays(CookiesConfigOptions.CookiesLifetimeInDays);
        
        contextAccessor.HttpContext?.Response
            .Cookies.Append(configuration["JWT:CookieName"]!, accessToken, cookieOptions);
        
        return true;
    }
}