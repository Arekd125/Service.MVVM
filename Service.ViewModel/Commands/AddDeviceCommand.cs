using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;

using Servis.Models.OrderModels;

namespace Service.ViewModel.Commands
{
    public class AddDeviceCommand : CommandBase
    {
        private readonly IDeviceStateService _deviceStateService;
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public AddDeviceCommand(CreatingOrderViewModel creatingOrderViewModel, IDeviceStateService deviceStateService)
        {
            _deviceStateService = deviceStateService;
            _creatingOrderViewModel = creatingOrderViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.DeviceNameComboBox))
                && _creatingOrderViewModel.DeviceNameComboBox.Length > 1
                && (string.IsNullOrEmpty(_creatingOrderViewModel.DeviceStateSelectedItem))
                && !IfExists(_creatingOrderViewModel.DeviceNameComboBox.TrimEnd());
        }

        private bool IfExists(string deviceStateName)
        {
            var devices = _deviceStateService.GetAllDeviceName().Result;
            return devices.Any(p => p == deviceStateName);
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            DeviceState deviceState = new()
            {
                Name = _creatingOrderViewModel.DeviceNameComboBox
            };

            _deviceStateService.CreateDevice(deviceState);
            _creatingOrderViewModel.DeviceStateNameItemsSource = _deviceStateService.GetAllDeviceName().Result;
            _creatingOrderViewModel.DeviceStateSelectedItem = _creatingOrderViewModel.DeviceNameComboBox;
        }
    }
}