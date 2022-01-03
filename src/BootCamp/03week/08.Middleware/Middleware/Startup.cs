using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Middleware.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Middleware", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Middleware v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Use Bloðu 1, Sonuç 1");
            //    await next();
            //    await context.Response.WriteAsync("Use Bloðu 1, Sonuç 1");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Use Bloðu 2, Sonuç 1");
            //    await context.Response.WriteAsync("Use Bloðu 2, Sonuç 2");
            //});

            //app.Map("/weather", app =>
            //{
            //    app.Run(async c => await c.Response.WriteAsync("Run middleware'i tetiklendi."));
            //});

            //app.MapWhen(x => x.Request.Method == "GET", mapWhen =>
            //{
            //    mapWhen.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("HTTP GET isteðinde bulunuldu");
            //        await next();
            //    });
            //});

            app.UseRequestTime();

        }
    }
}
