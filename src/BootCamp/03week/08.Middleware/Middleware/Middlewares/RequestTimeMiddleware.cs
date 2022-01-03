using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{

	public class RequestTimeMiddleware
    {
        readonly RequestDelegate _next;
        public RequestTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string sure = "";

            sure += DateTime.Now.TimeOfDay.ToString() + " start "+ Environment.NewLine;
           
            await _next(context);

            sure += DateTime.Now.TimeOfDay.ToString() + " end " + Environment.NewLine;

            File.AppendAllText("time.txt", sure);
        }
    }

}
