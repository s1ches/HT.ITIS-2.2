using System.Net;

namespace GoodWebSite.RazorExample.Middlewares;

public class HttpErrorMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);
        
        if(context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            context.Response.Redirect("Auth/Login");
    }
}