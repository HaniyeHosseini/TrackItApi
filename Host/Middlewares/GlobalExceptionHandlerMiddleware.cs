using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SlackNet.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Exceptions;
using TrackItApi.Common;

namespace Host.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(BaseException ex)
        {
            _logger.LogError(ex, "handled exception occurred");
            context.Response.StatusCode = ex.StatusCode;
            var errorResponse = new
            {
                Message = ex.Message,
                ErrorCode = ex.ErrorCode,
                ex.StatusCode
            };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");
            var errorResponse = new
            {
                Message = ExceptionMessages.InternalServerError,
                ErrorCode = "SERVER_ERROR",
                context.Response.StatusCode
            };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
