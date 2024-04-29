using Microsoft.Extensions.DependencyInjection;
using Service.ViewModel.Mapping;
using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddViewModel(this IServiceCollection services)

        {
            services.AddAutoMapper(typeof(OrderMappingProfile));
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IDeviceStateService, DeviceStateService>();
            services.AddSingleton<OrdersListingViewModel>();
            services.AddSingleton<CreatingOrderViewModel>();

        }
    }
}