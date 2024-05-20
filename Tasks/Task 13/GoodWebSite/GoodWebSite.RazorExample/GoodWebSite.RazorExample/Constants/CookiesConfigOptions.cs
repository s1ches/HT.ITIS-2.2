namespace GoodWebSite.RazorExample.Constants;

public static class CookiesConfigOptions
{
    public const int CookiesLifetimeInDays = 7;
    
    public static readonly CookieOptions BaseCookiesOptions = new()
    {
        Secure = true,
        SameSite = SameSiteMode.None,
    };
}