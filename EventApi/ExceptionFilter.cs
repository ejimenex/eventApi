using EventApi.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventApi;
public class ExceptionHandlingMiddleware(
 RequestDelegate next,
 ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (FluentValidationException ex)
        {
            logger.LogError(ex, "Exception ocurred: {Message}", ex.Message);

            var problemDetails = new ProblemDetails
            {

                Title = "Error interno",
                Detail = ex.Message,
            };

            if (ex.Errors is not null)
            {
                problemDetails.Extensions["errors"] = ex.Errors;
            }

           context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (CustomException ex)
        {
            logger.LogError(ex, "Exception ocurred: {Message}", ex.Message);

            var problemDetails = new ProblemDetails
            {

                Title = "Error interno",
                Detail = ex.Message,
            };

            
                problemDetails.Extensions["errors"] = ex.Message;
            

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}

