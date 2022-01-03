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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transient.Singleton.Scoped.Services;

namespace Transient.Singleton.Scoped
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transient.Singleton.Scoped", Version = "v1" });
            });

            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use((context, next) =>
                {

                    var singleton = context.RequestServices.GetRequiredService<SingletonService>();
                    var scoped = context.RequestServices.GetRequiredService<ScopedService>();
                    var transient = context.RequestServices.GetRequiredService<TransientService>();

                    singleton.Counter++;
                    scoped.Counter++;
                    transient.Counter++; 

                    return next();

            });

            app.Run(async context =>
            {
                var singleton = context.RequestServices.GetRequiredService<SingletonService>();
                var scoped = context.RequestServices.GetRequiredService<ScopedService>();
                var transient = context.RequestServices.GetRequiredService<TransientService>();

                singleton.Counter++;
                scoped.Counter++;
                transient.Counter++;


                await context.Response.WriteAsync($"Singleton: { singleton.Counter}\n");
                await context.Response.WriteAsync($"Scoped: { scoped.Counter}\n");
                await context.Response.WriteAsync($"Transient: { transient.Counter}\n");


            });
        }
    }
}
