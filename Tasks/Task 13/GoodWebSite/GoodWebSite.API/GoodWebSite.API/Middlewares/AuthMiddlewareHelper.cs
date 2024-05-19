namespace GoodWebSite.Middlewares;

public class AuthMiddlewareHelper(string accessTokenCookieName) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Cookies.TryGetValue(accessTokenCookieName, out var token))
            context.Request.Headers.Authorization = $"Bearer {token}";
        
        await next(context);
    }
}