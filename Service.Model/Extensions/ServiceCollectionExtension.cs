using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Model.DbContexts;

using Service.Model.Repositories;

namespace Service.Model.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbConnection(this IServiceCollection services, IConfiguration configuration)

        {
            string connectionString = configuration.GetConnectionString("Default");

            services.AddSingleton(new OrdersDbContextFactory(connectionString));
        }

        public static void AddModel(this IServiceCollection services)

        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
        }
    }
}