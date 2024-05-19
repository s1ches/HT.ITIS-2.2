using System.Net;
using GoodWebSite.Exceptions;

namespace GoodWebSite.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ApplicationExceptionBase e)
        {
            context.Response.StatusCode = (int)e.StatusCode;
            await context.Response.WriteAsJsonAsync(new { message = e.Message });
        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new { message =  e.Message});
        }
    }
}