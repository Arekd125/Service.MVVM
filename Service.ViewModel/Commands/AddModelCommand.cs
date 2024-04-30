using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Commands
{
    public class AddModelCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public AddModelCommand(CreatingOrderViewModel creatingOrderViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.DeviceStateSelectedItem))
           && (string.IsNullOrEmpty(_creatingOrderViewModel.ModelStateSelectedItem))
           && (!string.IsNullOrEmpty(_creatingOrderViewModel.ModelNameComboBox))
           && _creatingOrderViewModel.ModelNameComboBox.Length > 1
           && !IfExists(_creatingOrderViewModel.ModelNameComboBox.TrimEnd());
        }

        private bool IfExists(string modelStateName)
        {
            var devices = _creatingOrderViewModel.AllModelStateName();
            return devices.Any(p => p == modelStateName);
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.SaveModelState();
        }
    }
}