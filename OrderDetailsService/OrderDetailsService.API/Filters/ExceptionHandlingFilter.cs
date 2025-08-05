using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using OrderDetailsService.API.Models;

namespace OrderDetailsService.API.Filters
{
    /// <summary>
    /// Exception filter for global API error handling.
    /// Ensures that all unhandled exceptions are caught, logged, and a friendly error response is returned to the client.
    /// </summary>
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionHandlingFilter> _logger;

        public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called when an exception occurs in the API pipeline.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public void OnException(ExceptionContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var exception = context.Exception;
            var traceId = context.HttpContext.TraceIdentifier;

            // Log the exception with traceId for correlation
            _logger.LogError(exception, "Unhandled exception occurred. TraceId: {TraceId}", traceId);

            // Determine the error response
            var errorResponse = new ErrorResponse
            {
                Message = GetUserFriendlyMessage(exception),
                Code = GetErrorCode(exception),
                Details = ShouldIncludeDetails(context) ? exception.ToString() : null,
                TraceId = traceId,
                Timestamp = DateTime.UtcNow
            };

            // Set the result
            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = GetStatusCode(exception)
            };

            context.ExceptionHandled = true;
        }

        private static string GetUserFriendlyMessage(Exception exception)
        {
            // Customize messages for known exception types if needed
            return exception switch
            {
                ArgumentException argEx => argEx.Message,
                KeyNotFoundException keyEx => keyEx.Message,
                _ => "Ocorreu um erro inesperado ao processar sua solicitação. Por favor, tente novamente ou contate o suporte."
            };
        }

        private static string GetErrorCode(Exception exception)
        {
            // Optionally map exception types to codes
            return exception switch
            {
                ArgumentException => "INVALID_ARGUMENT",
                KeyNotFoundException => "NOT_FOUND",
                _ => "UNEXPECTED_ERROR"
            };
        }

        private static int GetStatusCode(Exception exception)
        {
            // Map exception types to HTTP status codes
            return exception switch
            {
                ArgumentException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }

        private static bool ShouldIncludeDetails(ExceptionContext context)
        {
#if DEBUG
            return true;
#else
            // Optionally, include details for local requests or based on configuration
            return false;
#endif
        }
    }
}