using MahApps.Metro.Controls.Dialogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Model.DbContexts;
using Service.Model.Extensions;
using Service.ViewModel.Commands;
using Service.ViewModel.Extensions;
using Service.ViewModel.ViewModels;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using System.Windows;

namespace Service.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private IDialogCoordinator dialogCoordinator;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbConnection(hostContext.Configuration);
                    services.AddModel();
                    services.AddViewModel();

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

            var viewModel = _host.Services.GetRequiredService<CreatingOrderViewModel>();

            viewModel.ShowMessageBoxRequested += (sender, message) =>
            {
                dialogCoordinator.ShowMessageAsync(this, "HEADER", "MESSAGE");
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}