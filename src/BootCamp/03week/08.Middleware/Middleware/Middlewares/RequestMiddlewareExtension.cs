using Microsoft.AspNetCore.Builder;

namespace Middleware.Middlewares
{
    public static class RequestMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestTime(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeMiddleware>();
        }
    }

}
