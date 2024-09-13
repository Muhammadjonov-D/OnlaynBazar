
using Microsoft.AspNetCore.Diagnostics;
using OnlaynBazar.Service.Exceptions;
using OnlaynBazar.WebApi.Models.Commons;

namespace OnlaynBazar.WebApi.Middlewares;

public class ArgumentIsNotValidExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        if (exception is not ArgumentIsNotValidException argumentIsNotValidException)
            return false;

        await httpContext.Response.WriteAsJsonAsync(new Response
        {
            StatusCode = argumentIsNotValidException.StatusCode,
            Message = argumentIsNotValidException.Message,
        });

        return true;
    }
}