using System.Net;

namespace GoodWebSite.Exceptions;

public class InternalServerErrorException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) 
    : ApplicationExceptionBase(message, statusCode);