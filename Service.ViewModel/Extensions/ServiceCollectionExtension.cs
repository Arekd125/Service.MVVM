using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Model.DbContexts;
using Service.ViewModel.Mapping;
using Service.ViewModel.Service.Commands.CreateDevice;
using Service.ViewModel.Stores;
using Service.ViewModel.Stores.OrdersFilter;
using Service.ViewModel.ViewModels;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using Service.ViewModel.ViewModels.PrintOrderViewModels;
using Service.ViewModel.ViewModels.StatusBarViewVModels;

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
            services.AddScoped<PrintOrderViewModel>();
            services.AddScoped<PrintViewModel>();
            services.AddSingleton<StatusBarViewModel>();
            services.AddSingleton<NameOrderViewModel>();
            services.AddSingleton<ContactViewModel>();
            services.AddSingleton<DeviceViewModel>();
            services.AddScoped<DescriptionViewModel>();
            services.AddScoped<FlyoutVewModel>();
            services.AddSingleton<OrderStore>();
            services.AddSingleton<ToDoStore>();
            services.AddSingleton<OrdersFilter>();
            services.AddScoped<InfoViewModel>();
            services.AddScoped<SettingsViewModel>();
        }

        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)

        {
            var aboutInfo = new AboutInfo();
            configuration.GetSection("AboutInfo").Bind(aboutInfo);

            services.AddSingleton(aboutInfo);
        }
    }
}