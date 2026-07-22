using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Common.Exceptions;
using EduMS.Application.Common.Responses;
using EduMS.Application.Common.Validation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EduMS.WebApi.Infrastructure;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An exception occurred: {Message}", exception.Message);

        var response = exception switch
        {
            ValidationException validationEx => HandleValidationException(httpContext, validationEx),
            NotFoundException notFoundEx => HandleNotFoundException(httpContext, notFoundEx),
            _ => HandleGenericException(httpContext)
        };

        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken: cancellationToken);

        return true;
    }

    private static ApiResponse<object> HandleValidationException(HttpContext httpContext, ValidationException ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        var errors = new List<string>();
        foreach (var error in ex.Errors)
        {
            errors.AddRange(error.Value);
        }

        return ApiResponse<object>.Failure("One or more validation errors occurred.", errors);
    }

    private static ApiResponse<object> HandleNotFoundException(HttpContext httpContext, NotFoundException ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        return ApiResponse<object>.Failure(ex.Message);
    }

    private static ApiResponse<object> HandleGenericException(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return ApiResponse<object>.Failure("An unexpected error occurred.");
    }
}
