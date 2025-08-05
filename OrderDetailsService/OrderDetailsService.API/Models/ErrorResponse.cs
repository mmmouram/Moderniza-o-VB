using System;
using System.Collections.Generic;

namespace OrderDetailsService.API.Models
{
    /// <summary>
    /// Standard error response model for API error handling.
    /// Used to return friendly error messages and details to the client,
    /// and to support error logging and troubleshooting.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// A user-friendly error message to be displayed to the end user.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Optional: A machine-readable error code for programmatic handling.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Optional: Additional details about the error (e.g., validation errors, stack trace in development).
        /// </summary>
        public object Details { get; set; }

        /// <summary>
        /// Optional: The date and time when the error occurred (UTC).
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Optional: A unique identifier for the error instance (for correlation and logging).
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// Creates a new error response with a message.
        /// </summary>
        /// <param name="message">The user-friendly error message.</param>
        public ErrorResponse(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Creates a new error response with message, code, details, and traceId.
        /// </summary>
        public ErrorResponse(string message, string code = null, object details = null, string traceId = null)
        {
            Message = message;
            Code = code;
            Details = details;
            TraceId = traceId;
        }

        /// <summary>
        /// Parameterless constructor for serialization.
        /// </summary>
        public ErrorResponse() { }
    }
}