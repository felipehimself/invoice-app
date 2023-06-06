using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace InvoiceApp.Middlewares
{
    public class GlobalExeptionMiddleware : IMiddleware
    {

        private readonly ILogger<GlobalExeptionMiddleware> _logger;

        public GlobalExeptionMiddleware(ILogger<GlobalExeptionMiddleware> logger)
        {
            _logger = logger;
        }



        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, message: e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                
                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = "An error ocurred in the server",
                };

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
    }
}
