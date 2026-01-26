using System.Net;
using System.Net.Http;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
var statusCode = exception switch
{

    ArgumentNullException or ArgumentException => (int)HttpStatusCode.BadRequest,

    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,

    InvalidOperationException when exception.Message.Contains("Identity") 
        => (int)HttpStatusCode.Forbidden,

    KeyNotFoundException => (int)HttpStatusCode.NotFound,

    DbUpdateException => (int)HttpStatusCode.Conflict,

    _ => (int)HttpStatusCode.InternalServerError
};

            var response = new
            {
                status = statusCode,
                message = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}