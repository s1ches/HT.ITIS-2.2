using System.Net;

namespace GoodWebSite.Exceptions;

public class ApplicationExceptionBase(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    : Exception(message)
{
    public HttpStatusCode StatusCode { get; set; } = statusCode;
}