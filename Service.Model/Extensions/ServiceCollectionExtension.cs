using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Model.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbConnection(this IServiceCollection services, IConfiguration configuration)

        {
            string connectionString = configuration.GetConnectionString("Default");

            //services.AddDbContext<OrdersDbContext>(options => options.UseSqlite(connectionString));

            services.AddSingleton(new OrdersDbContextFactory(connectionString));
        }
    }
}