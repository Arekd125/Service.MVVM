using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Commands
{
    public class AddModelCommand : CommandBase
    {
        private readonly DeviceViewModel _deviceViewModel;

        public AddModelCommand(DeviceViewModel deviceViewModel)
        {
            _deviceViewModel = deviceViewModel;
            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_deviceViewModel.DeviceStateSelectedItem))
           && (string.IsNullOrEmpty(_deviceViewModel.ModelStateSelectedItem))
           && (!string.IsNullOrEmpty(_deviceViewModel.ModelNameComboBox))
           && _deviceViewModel.ModelNameComboBox.Length > 1
           && !IfExists(_deviceViewModel.ModelNameComboBox.TrimEnd());
        }

        private bool IfExists(string modelStateName)
        {
            var devices = _deviceViewModel.AllModelStateName();
            return devices.Any(p => p == modelStateName);
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _deviceViewModel.SaveModelState();
        }
    }
}