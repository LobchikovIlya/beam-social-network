using System.Net;

namespace Beam.Core.Exceptions;

public class BadRequestException : ExceptionBase
{
    public BadRequestException(string message, HttpStatusCode httpStatusCode) : base(message, httpStatusCode)
    {
    }
}