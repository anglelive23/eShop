﻿namespace eShop.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        #region Fields and Properties
        private readonly RequestDelegate _next;
        #endregion

        #region Constructors
        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        #endregion

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleGlobalExceptionAsync(context, ex);
            }
        }
        private Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = Guid.NewGuid();
            switch (exception)
            {
                case FluentValidation.ValidationException validationException:
                    {
                        StringBuilder message = new StringBuilder();
                        foreach (var error in validationException.Errors)
                        {
                            message.AppendLine(error.ErrorMessage);
                        }
                        Log.ForContext("ValidationError", message.ToString())
                            .Error($"Validation error with code: {errorCode} occurred in Application Layer.");
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return context.Response.WriteAsJsonAsync(new
                        {
                            ErrorCode = errorCode,
                            Message = "Validation Error occurred in Application Layer.",
                            ErrorMessage = message.ToString()
                        });
                    }

                case DataFailureException dataFailureException:
                    {
                        var message = dataFailureException.InnerException != null ? dataFailureException.InnerException.Message : dataFailureException.Message;
                        Log.ForContext("DataFailureError", message)
                            .Error($"Data Failure Error with code: {errorCode} occurred in Infrastructure Layer, Contact system admin with ErrorCode.");
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return context.Response.WriteAsJsonAsync(new
                        {
                            ErrorCode = errorCode,
                            Message = "Data Failure Error occurred in Infrastructure Layer.",
                            ErrorMessage = message
                        });
                    }

                default:
                    {
                        Log.ForContext("ErrorCode", errorCode)
                           .Error(exception, $"An Error with code: {errorCode} occured in API");
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return context.Response.WriteAsJsonAsync(new
                        {
                            ErrorCode = errorCode,
                            Message = "An exception was thrown in the system.",
                            ErrorMessage = exception.Message
                        });
                    }
            }
        }
    }
}
