using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Commands
{
    public class AddDeviceCommand : CommandBase
    {
        private readonly IDeviceStateService _deviceStateService;
        private readonly DeviceViewModel _deviceViewModel;

        public AddDeviceCommand(DeviceViewModel deviceViewModel, IDeviceStateService deviceStateService)
        {
            _deviceViewModel = deviceViewModel;
            _deviceStateService = deviceStateService;

            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_deviceViewModel.DeviceNameComboBox))
                && _deviceViewModel.DeviceNameComboBox.Length > 1
                && (string.IsNullOrEmpty(_deviceViewModel.DeviceStateSelectedItem))
                && !IfExists(_deviceViewModel.DeviceNameComboBox.TrimEnd());
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
            _deviceViewModel.SaveDeviceState();

            

            
        }
    }
}