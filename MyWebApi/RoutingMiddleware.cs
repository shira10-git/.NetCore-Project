using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Services;
using System.IO;
using System.Threading.Tasks;

namespace MyWebApi
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext,IRatingService ratingService)
        {
            Rating r = new Rating();
            r.Host = httpContext.Request.Host.Host;
            r.Method = httpContext.Request.Method;
            r.Path = httpContext.Request.Path;
            r.Referer = httpContext.Request.Headers["Referer"];
            r.UserAgent = httpContext.Request.Headers.UserAgent;
            //Rating r = new Rating(Host, Method, Path, Referer, UserAgent);
            ratingService.Post(r);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RoutingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRoutingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingMiddleware>();
        }
    }
}
