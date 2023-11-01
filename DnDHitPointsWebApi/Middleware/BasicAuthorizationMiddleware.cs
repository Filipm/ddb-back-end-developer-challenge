using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DnDHitPointsWebApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Auth"].FirstOrDefault();

            if(token == "ABCYesxyz")
            {
                httpContext.Items["Authorized"] = "Yes";
            }
            else
            {
                httpContext.Items["Authorized"] = "No";
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthorizationMiddleware>();
        }
    }
}
