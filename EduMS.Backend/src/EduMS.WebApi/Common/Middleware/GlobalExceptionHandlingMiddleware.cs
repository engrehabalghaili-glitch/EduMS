using System.Net;
using System.Text.Json;
using EduMS.Application.Common.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EduMS.WebApi.Common.Middleware;

public class GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            logger.LogWarning(ex, "Validation error occurred while handling request.");
            await HandleValidationExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred while handling request.");
            await HandleGenericExceptionAsync(context, ex);
        }
    }

    private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new
        {
            status = (int)HttpStatusCode.BadRequest,
            title = "Validation Failed",
            detail = "One or more validation errors occurred while processing your request.",
            errors = exception.Errors
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleGenericExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            status = (int)HttpStatusCode.InternalServerError,
            title = "Internal Server Error",
            detail = "An unexpected error occurred while processing your request."
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
