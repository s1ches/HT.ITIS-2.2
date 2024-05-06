using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Identity.API.Services.IdentityServices;

public class TokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : IdentityUser<Guid> 
{
    private readonly IDistributedCache _cache;

    public TokenProvider(IDataProtectionProvider dataProtectionProvider, 
        IOptions<TokenProviderOptions> options, 
        ILogger<DataProtectorTokenProvider<TUser>> logger, IDistributedCache cache) 
        : base(dataProtectionProvider, options, logger)
    {
        _cache = cache;
    }

    public override async Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
    {
        var rnd = new Random();
        var token = string.Empty;

        for (var i = 0; i < 6; ++i)
            token += rnd.Next(0, 10).ToString();

        await _cache.SetStringAsync(token, user.Email!);
        return token;
    }

    public override async Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
    {
        var email = await _cache.GetStringAsync(token);

        if (email is null || email != user.Email)
            return false;
        
        await _cache.RemoveAsync(token);
        return true;
    }
}

public class TokenProviderOptions : DataProtectionTokenProviderOptions
{
}