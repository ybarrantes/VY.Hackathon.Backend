using System.Text.Json;
using VY.Hackathon.Backend.Domain.Extensions;
using VY.Hackathon.Backend.Domain.Poco;
using VY.Hackathon.Backend.Domain.Types;

namespace VY.Hackathon.Backend.WebApi.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var operationResult = new OperationResult<object>(new ErrorResult("Unexpected error!", e, ErrorType.Unhandled));
            var result = JsonSerializer.Serialize(operationResult.MapToResultDto());
            await context.Response.WriteAsync(result);
        }
    }
}