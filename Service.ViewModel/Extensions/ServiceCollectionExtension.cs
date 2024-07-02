using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
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

            var inprint = new Inprint();
            configuration.GetSection("InprintInfo").Bind(inprint);

            services.AddSingleton(inprint);
        }

        public static class AppSettingsHelper
        {
            private static readonly string AppSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            public static void UpdateInprintSettings(Inprint inprint)
            {
                var json = File.ReadAllText(AppSettingsPath);
                var jsonObj = JObject.Parse(json);
                var inprintSection = jsonObj["InprintInfo"];

                if (inprintSection == null)
                {
                    inprintSection = new JObject();
                    jsonObj["InprintInfo"] = inprintSection;
                }

                inprintSection["Name"] = inprint.Name;
                inprintSection["Street"] = inprint.Street;
                inprintSection["City"] = inprint.City;
                inprintSection["Zipcode"] = inprint.Zipcode;
                inprintSection["PhoneNumner1"] = inprint.PhoneNumner1;
                inprintSection["PhoneNumner2"] = inprint.PhoneNumner2;
                inprintSection["Mail"] = inprint.Mail;

                File.WriteAllText(AppSettingsPath, jsonObj.ToString());
            }
        }
    }
}