using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace InvoiceApp.Middlewares
{
    public class GlobalExeptionMiddleware : IMiddleware
    {


        public GlobalExeptionMiddleware()
        {

        }



        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {

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
