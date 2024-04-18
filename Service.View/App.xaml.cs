﻿using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Service.Model.Services;
using Service.Model.Services.ServicesDevice;
using Service.ViewModel.ViewModels;
using Servis.Models.OrderModels;
using System.Windows;

namespace Service.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly IOrderCreator _orderCreator;

        // private readonly List<Order> _orders;
        private readonly OrdersDbContextFactory _ordersDbContextFactory;

        private readonly DatabaseOrderCreator _orderCreator;
        private readonly IDeviceCreator _deviceCreator;
        private readonly IDeviceProvider _deviceProvider;
        private readonly IOrderProviders _orderProviders;
        private const string CONNECTION_STRING = "Data Source=serviceDB.db";

        public App()
        {
            _ordersDbContextFactory = new OrdersDbContextFactory(CONNECTION_STRING);
            _orderCreator = new DatabaseOrderCreator(_ordersDbContextFactory);
            _orderProviders = new DatabaseOrderProvider(_ordersDbContextFactory);
            _deviceCreator = new DatabaseDeviceCreator(_ordersDbContextFactory);
            _deviceProvider = new DatabaseDeviceProvider(_ordersDbContextFactory);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (OrdersDbContext dbContext = _ordersDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_orderCreator, _orderProviders, _deviceProvider, _deviceCreator)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}