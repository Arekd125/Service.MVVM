using Microsoft.EntityFrameworkCore;
using Service.Model.DbContexts;
using Service.Model.Services;
using Service.ViewModel;
using Service.ViewModel.ViewModels;
using Servis.Models.OrderModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Service.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IOrderCreator _orderCreator;
        private readonly IOrderProviders _orderProviders;

        private readonly List<Order> _orders;
        private const string CONNECTION_STRING = "Data Source=serviceDB.db";

        public App()
        {
            _orders = new List<Order>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (OrdersDbContext dbContext = new OrdersDbContext(options))
            {
                dbContext.Database.Migrate();
            }

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_orders)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}