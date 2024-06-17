using MahApps.Metro.Controls.Dialogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Model.DbContexts;
using Service.Model.Extensions;
using Service.View.Views.PrintOrderViews;
using Service.ViewModel.Extensions;
using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;
using System.Windows;

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
                    services.AddScoped<IDialogCoordinator>(s => DialogCoordinator.Instance);
                    services.AddSingleton<IDialogService, DialogService>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainWindowViewModel>()
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