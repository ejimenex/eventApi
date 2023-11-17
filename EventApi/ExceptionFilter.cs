using EventApi.Application.Exceptions;
using EventApi.Infrasestructure.Model;
using System.Net;
using System.Text.Json;

namespace EventApi
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var validationJson = string.Empty;
                var statusCode = HttpStatusCode.InternalServerError; // 500 if unexpected

                switch (ex)
                {

                    case FriendlyException friendlyException:
                        statusCode = HttpStatusCode.BadRequest;
                        validationJson = JsonSerializer.Serialize(friendlyException.Message);
                        break;
                    case CustomException customException:
                        statusCode = HttpStatusCode.BadRequest;
                        validationJson = JsonSerializer.Serialize(customException.Message);
                        break;
                    case ArgumentException argumentException:
                        statusCode = HttpStatusCode.BadRequest;
                        break;
                    default:
                        break;
                }

                var message = ex.Message;

                if (!string.IsNullOrEmpty(validationJson))
                {
                    message = $"{validationJson} ";
                }

                var responseModel = Result<string>.Fail(message, statusCode.ToString());

                if (!_env.IsProduction())
                {
                    responseModel = Result<string>.Fail(message, $"Error {(int)statusCode} - {statusCode}", ex.StackTrace);
                }

                var result = JsonSerializer.Serialize(responseModel);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(result);
            }
        }
    }
}

