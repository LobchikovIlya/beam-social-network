using Beam.Core.Exceptions;
using Beam.Shared.Responses;
using Newtonsoft.Json;

namespace Beam.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            HandleException(context, exception);
        }
    }

    private void HandleException(HttpContext context, Exception exception)
    {
        int statusCode;
        ErrorResponse errorResponse;
        if (exception is ExceptionBase customException)
        {
            statusCode = (int)customException.HttpStatusCode;
            errorResponse = new ErrorResponse(exception.Message, exception.StackTrace);
        }
        else
        {
            statusCode = 500; // Internal Server Error
            errorResponse = new ErrorResponse("Internal Server Error", exception.StackTrace);
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        var responseJson = JsonConvert.SerializeObject(errorResponse);

        context.Response.WriteAsync(responseJson);
    }
}