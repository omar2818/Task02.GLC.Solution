using DomainLayer.Exceptions;
using Shared.ErrorModels;
using System.Net;
using System.Text.Json;

namespace E_Commerce.Web.CustomMiddleWares
{
    public class CustomExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleWare> _logger;

        public CustomExceptionHandlerMiddleWare(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async System.Threading.Tasks.Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // Requset

                await _next.Invoke(httpContext);

                // Response
                await HandleNotFoundEndPointAsync(httpContext);
                await HandleUnAuthAsync(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something Went Wrong");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async System.Threading.Tasks.Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // Set Status Code for Response
            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            // Response Objcet
            var response = new ErrorToReturn()
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message
            };

            await httpContext.Response.WriteAsJsonAsync(response);
        }

        private static async System.Threading.Tasks.Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"End Point {httpContext.Request.Path} is Not Found"
                };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
        private static async System.Threading.Tasks.Task HandleUnAuthAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                var response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    ErrorMessage = "UnAuthorized, please login and try again"
                };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
