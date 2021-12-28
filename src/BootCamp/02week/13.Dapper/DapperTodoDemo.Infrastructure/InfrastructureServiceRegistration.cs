using Autofac;
using AutoMapper.Configuration;
using DapperTodoDemo.Application.Repositories;
using DapperTodoDemo.Application.Services;
using DapperTodoDemo.Infrastructure.Repositories;
using DapperTodoDemo.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DapperTodoDemo.Infrastructure.Settings;

namespace DapperTodoDemo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            ConnectionSettings.ConnectionString = configuration.GetConnectionString("TodoConnectionString");

            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<ITodoItemAppService, TodoItemAppService>();




            return services;
        }
    }
}
