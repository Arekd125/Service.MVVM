using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Model.DbContexts;
using Service.ViewModel.Mapping;
using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddViewModel(this IServiceCollection services)

        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddAutoMapper(typeof(OrderMappingProfile));
        }
    }
}