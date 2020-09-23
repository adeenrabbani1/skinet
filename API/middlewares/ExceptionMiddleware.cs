using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


//Custom middlewares, must include certain methods and props
namespace API.middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }
        //this is a must have method for the custom middlewares in .net
        //should expect a parameter. HttpContext 

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //incase of a serverside exception, here we will
                //generate the response that we want to send in this case.
                _logger.LogError(ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var res = _env.IsDevelopment() ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                new ApiException((int)HttpStatusCode.InternalServerError);
                var JsonResponse = JsonSerializer.Serialize(res, jsonOptions);

                await context.Response.WriteAsync(JsonResponse);



            }
        }
    }
}