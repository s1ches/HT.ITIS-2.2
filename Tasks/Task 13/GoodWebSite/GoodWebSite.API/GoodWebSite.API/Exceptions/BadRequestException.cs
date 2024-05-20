using System.Net;

namespace GoodWebSite.Exceptions;

public class BadRequestException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    : ApplicationExceptionBase(message, statusCode);