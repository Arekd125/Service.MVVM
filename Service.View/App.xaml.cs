﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Model.DbContexts;
using Service.Model.Services;
using Service.Model.Services.ServicesDevice;
using Service.ViewModel.ViewModels;
using Servis.Models.OrderModels;
using System.Windows;
using Service.Model.Extensions;
using System.Configuration;
using Service.ViewModel.Extensions;
using Service.Model.Interfaces;
using Service.Model.Repositories;

namespace Service.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbConnection(hostContext.Configuration);
                    services.AddModel();
                    services.AddViewModel();

                    services.AddSingleton<IDeviceCreator, DatabaseDeviceCreator>();
                    services.AddSingleton<IDeviceProvider, DatabaseDeviceProvider>();

                    services.AddScoped<MainViewModel>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            OrdersDbContextFactory _ordersDbContextFactory = _host.Services.GetRequiredService<OrdersDbContextFactory>();
            using (OrdersDbContext dbContext = _ordersDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}