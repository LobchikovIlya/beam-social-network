using System.Net;

namespace Beam.Core.Exceptions;

public class InternalServerErrorException : ExceptionBase
{
    public InternalServerErrorException(string message, HttpStatusCode httpStatusCode) : base(message, httpStatusCode)
    {
    }
}