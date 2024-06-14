using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using MediatR;
using Service.ViewModel.Commands.CreatingOrderCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Commands.CreateDevice;
using Service.ViewModel.Service.Commands.CreateModelDevice;
using Service.ViewModel.Service.Commands.DeleteModelDevice;
using Service.ViewModel.Service.Queries.GetAllDeviceName;
using Service.ViewModel.Service.Queries.GettAllModelName;
using System.Windows.Input;
using System.Windows.Media;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class DeviceViewModel : ViewModelBase

    {
        public IDialogCoordinator _dialogCoordinator;
        private readonly FlyoutVewModel _flyoutVewModel;
        private readonly IMediator _mediator;

        public ICommand AddDeviceButton { get; }
        public ICommand DeleteDeviceButton { get; }

        public ICommand AddModelButton { get; }
        public ICommand DeleteModelButton { get; }

        private IEnumerable<string>? _deviceStateNameItemsSource;

        public IEnumerable<string>? DeviceStateNameItemsSource
        {
            get
            {
                return _deviceStateNameItemsSource;
            }
            set
            {
                _deviceStateNameItemsSource = value;
                OnPropertyChanged(nameof(DeviceStateNameItemsSource));
            }
        }

        private IEnumerable<string>? _modelStateNameItemSorceComboBox;

        public IEnumerable<string>? ModelStateNameItemSorce
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

        private string? _deviceStateSelectedItem = default!;

        public string? DeviceStateSelectedItem
        {
            get
            {
                return _deviceStateSelectedItem;
            }
            set
            {
                _deviceStateSelectedItem = value;
                OnPropertyChanged(nameof(DeviceStateSelectedItem));
                ModelStateNameItemSorce = _mediator.Send(new GetAllModelNameQuery(DeviceStateSelectedItem)).Result;
            }
        }

        private string? _modelStateSelectedItem = string.Empty;

        public string? ModelStateSelectedItem
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

        private string _deviceName = default!;

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

        private string _ModelName = default!;

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

        public DeviceViewModel(IMediator mediator, IDialogCoordinator dialogCoordinator, FlyoutVewModel flayoutVewModel)
        {
            _mediator = mediator;
            _dialogCoordinator = dialogCoordinator;
            _flyoutVewModel = flayoutVewModel;

            AddDeviceButton = new AddDeviceButtonCommand(this, mediator);
            DeleteDeviceButton = new DeleteDeviceButtonCommand(this);
            AddModelButton = new AddModelButtonnCommand(this);
            DeleteModelButton = new DeleteModelButtonCommand(this);
            DeviceStateNameItemsSource = _mediator.Send(new GetAllDeviceNameQuery()).Result;
        }

        public async void ShowMessage()
        {
            var themes = ThemeManager.Current.DetectTheme().Resources;
            themes["Theme.ThemeInstance"] = ThemeManager.Current.GetTheme("Light.Red");

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Tak",
                NegativeButtonText = "Anuluj",
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
            await _mediator.Send(new Service.Commands.DeleteDevice.DeleteDeviceCommand(DeviceStateSelectedItem));
            var message = $"Usunięto markę:\n{DeviceStateSelectedItem}";
            DeviceStateSelectedItem = null;
            DeviceStateNameItemsSource = _mediator.Send(new GetAllDeviceNameQuery()).Result;

            await _flyoutVewModel.ShowFlyout(message, Colors.Red);
        }

        public async void DeleteModel()
        {
            await _mediator.Send(new DeleteModelDeviceCommand(DeviceStateSelectedItem, ModelStateSelectedItem));
            var message = $"Usunięto model:\n{ModelStateSelectedItem}";
            ModelStateSelectedItem = null;
            ModelStateNameItemSorce = _mediator.Send(new GetAllModelNameQuery(DeviceStateSelectedItem)).Result;

            await
                _flyoutVewModel.ShowFlyout(message, Colors.Red);
        }

        public IEnumerable<string> AllModelStateName()
        {
            return _mediator.Send(new GetAllModelNameQuery(DeviceStateSelectedItem)).Result;
        }

        public async Task SaveDeviceState()

        {
            CreateDeviceCommand command = new()
            {
                Name = DeviceNameComboBox
            };
            await _mediator.Send(command);
            DeviceStateNameItemsSource = await _mediator.Send(new GetAllDeviceNameQuery());
            DeviceStateSelectedItem = DeviceNameComboBox;

            var message = $"Dodano markę:\n{DeviceNameComboBox}";
            await _flyoutVewModel.ShowFlyout(message);
        }

        public async Task SaveModelState()
        {
            ModelStateDto modelState = new()
            {
                Name = ModelNameComboBox
            };

            var deviceStateName = DeviceStateSelectedItem;
            await _mediator.Send(new CreateModelDeviceCommand(modelState, deviceStateName));
            ModelStateNameItemSorce = AllModelStateName();
            ModelStateSelectedItem = ModelNameComboBox;

            var message = $"Dodano model:\n{ModelNameComboBox}";
            await _flyoutVewModel.ShowFlyout(message);
        }

        public void Clear()
        {
            DeviceNameComboBox = string.Empty;
            ModelNameComboBox = string.Empty;
        }
    }
}