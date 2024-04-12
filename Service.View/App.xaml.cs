using Service.ViewModel;
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
        private readonly List<Order> _orders;

        public App()
        {
            _orders = new List<Order>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_orders)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}