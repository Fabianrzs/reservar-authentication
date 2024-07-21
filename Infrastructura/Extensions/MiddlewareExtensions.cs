using Infrastructura.Middleware;
using Microsoft.AspNetCore.Builder;
namespace Infrastrunture.Extensions;
public static class MiddlewareExtensions
{
    public static void UseExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}

