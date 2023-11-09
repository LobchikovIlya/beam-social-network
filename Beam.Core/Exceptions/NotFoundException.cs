using System.Net;

namespace Beam.Core.Exceptions;

public class NotFoundException : ExceptionBase
{
    public NotFoundException(string message, HttpStatusCode httpStatusCode) : base(message, httpStatusCode)
    {
    }
}