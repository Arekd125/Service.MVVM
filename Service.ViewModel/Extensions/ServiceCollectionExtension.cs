﻿using MahApps.Metro.Controls.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Service.ViewModel.Commands;
using Service.ViewModel.Mapping;
using Service.ViewModel.Service;
using Service.ViewModel.Stores;
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
            services.AddTransient<IToDoService, ToDoService>();

            services.AddSingleton<OrdersListingViewModel>();
            services.AddSingleton<CreatingOrderViewModel>();
            services.AddSingleton<ToDoListViewModel>();
            services.AddScoped<MainWindowViewModel>();

            services.AddSingleton<NameOrderViewModel>();
            services.AddSingleton<ContactViewModel>();
            services.AddSingleton<DeviceViewModel>();
            services.AddSingleton<DescriptionViewModel>();
            services.AddScoped<FlyoutVewModel>();
            services.AddSingleton<OrderStore>();
            services.AddSingleton<ToDoStore>();
        }
    }
}