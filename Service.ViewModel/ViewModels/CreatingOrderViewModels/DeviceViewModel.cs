using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using Service.ViewModel.Commands;
using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public  class DeviceViewModel : ViewModelBase

    {
        public IDialogCoordinator _dialogCoordinator;
        private readonly FlayoutVewModel _flayoutVewModel;
        private readonly IDeviceStateService _deviceStateService;
        public ICommand AddDeviceButton { get; }
        public ICommand DeleteDeviceButton { get; }

        public ICommand AddModelButton { get; }
        public ICommand DeleteModelButton { get; }

       


       


        private IEnumerable<string> _deviceStateNameItemsSource;

        public IEnumerable<string> DeviceStateNameItemsSource
        {
            get
            {
                _deviceStateNameItemsSource = _deviceStateService.GetAllDeviceName().Result;
                return _deviceStateNameItemsSource;
            }
            set
            {
                _deviceStateNameItemsSource = value;
                OnPropertyChanged(nameof(DeviceStateNameItemsSource));
            }
        }

        private IEnumerable<string> _modelStateNameItemSorceComboBox;

        public IEnumerable<string> ModelStateNameItemSorce
        {
            get
            {
                return _modelStateNameItemSorceComboBox;
            }
            set
            {
                _modelStateNameItemSorceComboBox = value;
                OnPropertyChanged(nameof(ModelStateNameItemSorce));
            }
        }

        private string _deviceStateSelectedItem = string.Empty;

        public string DeviceStateSelectedItem
        {
            get
            {
                return _deviceStateSelectedItem;
            }
            set
            {
                _deviceStateSelectedItem = value;
                OnPropertyChanged(nameof(DeviceStateSelectedItem));
                ModelStateNameItemSorce = _deviceStateService.GetAllModelName(DeviceStateSelectedItem).Result;
            }
        }

        private string _modelStateSelectedItem = string.Empty;

        public string ModelStateSelectedItem
        {
            get
            {
                return _modelStateSelectedItem;
            }
            set
            {
                _modelStateSelectedItem = value;
                OnPropertyChanged(nameof(ModelStateSelectedItem));
            }
        }

        private string _deviceName = string.Empty;

        public string DeviceNameComboBox
        {
            get
            {
                return _deviceName;
            }
            set
            {
                _deviceName = value;
                OnPropertyChanged(nameof(DeviceNameComboBox));
            }
        }

        private string _ModelName = string.Empty;
       

        public string ModelNameComboBox
        {
            get
            {
                return _ModelName;
            }
            set
            {
                _ModelName = value;
                OnPropertyChanged(nameof(ModelNameComboBox));
            }
        }

        public DeviceViewModel(IDeviceStateService deviceStateService, IDialogCoordinator dialogCoordinator, FlayoutVewModel flayoutVewModel )
        {

            _deviceStateService = deviceStateService;
            _dialogCoordinator = dialogCoordinator;
            _flayoutVewModel = flayoutVewModel;



            AddDeviceButton = new AddDeviceCommand(this, deviceStateService);
            DeleteDeviceButton = new DeleteDeviceCommand(this);
            AddModelButton = new AddModelCommand(this);
            DeleteModelButton = new DeleteModelCommand(this);


        }




        public async void ShowMessage()
        {
            var themes = ThemeManager.Current.DetectTheme().Resources;
            themes["Theme.ThemeInstance"] = ThemeManager.Current.GetTheme("Light.Red");

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Tak",
                NegativeButtonText = "Anuluj",
                AnimateShow = false,
                CustomResourceDictionary = themes,
                ColorScheme = MetroDialogColorScheme.Accented
            };

            var title = $"Usunąć markę {DeviceStateSelectedItem}?";
            var models = string.Join(", ", ModelStateNameItemSorce);
            var message = $"Zostaną również usunięte następujące modele: {models}";

            MessageDialogResult result = await _dialogCoordinator.ShowMessageAsync(
                                            this,
                                            title,
                                            message,
                                            MessageDialogStyle.AffirmativeAndNegative,
                                            mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                DeleteDeviceAndModels();
            }
        }

        public async void DeleteDeviceAndModels()
        {
            await _deviceStateService.DeleteDevice(DeviceStateSelectedItem);
            var message = $"Usunięto Markę {DeviceStateSelectedItem}";
            DeviceStateSelectedItem = null;
            DeviceStateNameItemsSource = _deviceStateService.GetAllDeviceName().Result;

            await _flayoutVewModel.ShowFlyout(message, Colors.Red);
        }



        public async void DeleteModel()
        {
            await _deviceStateService.DeleteModel(DeviceStateSelectedItem, ModelStateSelectedItem);
            var message = $"Usunięto Modelu {ModelStateSelectedItem}";
            ModelStateSelectedItem = null;
            ModelStateNameItemSorce = _deviceStateService.GetAllModelName(DeviceStateSelectedItem).Result;

            await 
                _flayoutVewModel.ShowFlyout(message, Colors.Red);
        }


        public IEnumerable<string> AllModelStateName()
        {
            return _deviceStateService.GetAllModelName(DeviceStateSelectedItem).Result;
        }

        public async Task SaveDeviceState()

        {
            DeviceState deviceState = new()
            {
                Name = DeviceNameComboBox
            };
            await _deviceStateService.CreateDevice(deviceState);
            DeviceStateNameItemsSource = await _deviceStateService.GetAllDeviceName();
            DeviceStateSelectedItem = DeviceNameComboBox;

            var message = $"Dodano Markę {DeviceNameComboBox}";
            await _flayoutVewModel.ShowFlyout(message);
        }

        public async Task SaveModelState()
        {
            ModelState modelState = new()
            {
                Name = ModelNameComboBox
            };

            var deviceStateName = DeviceStateSelectedItem;
            await _deviceStateService.AddModel(modelState, deviceStateName);
            ModelStateNameItemSorce = AllModelStateName();
            ModelStateSelectedItem = ModelNameComboBox;

            var message = $"Dodano Model {ModelNameComboBox}";
            await _flayoutVewModel.ShowFlyout(message);
        }



    }
}
