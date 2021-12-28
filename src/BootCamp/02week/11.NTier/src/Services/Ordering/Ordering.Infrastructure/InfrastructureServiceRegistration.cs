using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Repository;
using Ordering.Application.Contracts.Services;
using Ordering.Infrastructure.Contracts.Repository;
using Ordering.Infrastructure.Contracts.Repository.Common;
using Ordering.Infrastructure.Contracts.Services;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
