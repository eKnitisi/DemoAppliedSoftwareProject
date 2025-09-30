using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using FV = FluentValidation;
using AP.BTP.Application.Exceptions;

namespace AP.BTP.WebAPI.Middleware
{
    public class OurOwnMiddelware
    {

    }
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = new ErrorResponseInfo();
                response.Message = ex.Message;
                switch (ex)
                {
                    case Application.Exceptions.ValidationException:
                    case FV.ValidationException:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case RelationNotFoundException:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    case LastCityDeletionNotAllowedException:
                        response.StatusCode = StatusCodes.Status409Conflict;
                        response.ErrorCode = "CANNOT_DELETE_LAST_CITY";
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

    public class ErrorResponseInfo
    {
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; } 
        public string Message { get; set; }
    }
}
