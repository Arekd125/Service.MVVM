using MahApps.Metro.Controls.Dialogs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Service.ViewModel.Commands;
using Service.ViewModel.Mapping;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Commands.CreateDevice;
using Service.ViewModel.Stores;
using Service.ViewModel.Stores.OrderFiltr;
using Service.ViewModel.Stores.OrdersFilter;
using Service.ViewModel.ViewModels;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddViewModel(this IServiceCollection services)

        {
            services.AddAutoMapper(typeof(OrderMappingProfile));
            services.AddMediatR(typeof(CreateDeviceCommand));
            services.AddSingleton<PanelControlViewModel>();
            services.AddSingleton<OrdersListingViewModel>();
            services.AddSingleton<OrderStatusTabControlViewModel>();
            services.AddSingleton<CreatingOrderViewModel>();
            services.AddSingleton<ToDoListViewModel>();
            services.AddScoped<MainWindowViewModel>();

            services.AddSingleton<NameOrderViewModel>();
            services.AddSingleton<ContactViewModel>();
            services.AddSingleton<DeviceViewModel>();
            services.AddScoped<DescriptionViewModel>();
            services.AddScoped<FlyoutVewModel>();
            services.AddSingleton<OrderStore>();
            services.AddSingleton<ToDoStore>();
            services.AddSingleton<OrdersFilter>();
           // services.AddScoped<>
        }
    }
}