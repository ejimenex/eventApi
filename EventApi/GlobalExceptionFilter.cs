using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace EventApi
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public GlobalExceptionFilter()
        {

        }
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;
                int statusCode;

                switch (true)
                {
                    //case bool _ when exception is BadRequestException:
                    //    statusCode = (int)HttpStatusCode.Unauthorized;
                    //    break;


                    case bool _ when exception is Exception:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case bool _ when exception is ArgumentException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
            }
        }
    }
}

