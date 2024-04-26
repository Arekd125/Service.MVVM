using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;
using Servis.Models.OrderModels;
using System.ComponentModel;
using System.Windows.Input;

namespace Service.ViewModel.Commands
{
    public class AddModelCommand : CommandBase
    {
        private readonly IDeviceStateService _deviceStateService;
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public AddModelCommand(CreatingOrderViewModel creatingOrderViewModel, IDeviceStateService deviceStateService)
        {
            _deviceStateService = deviceStateService;
            _creatingOrderViewModel = creatingOrderViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.DeviceStateSelectedItem))
           && (string.IsNullOrEmpty(_creatingOrderViewModel.ModelStateSelectedItem))
           && (!string.IsNullOrEmpty(_creatingOrderViewModel.ModelNameComboBox))
           && _creatingOrderViewModel.ModelNameComboBox.Length > 1;
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            ModelState modelState = new ModelState()
            {
                Name = _creatingOrderViewModel.ModelNameComboBox
            };
            var deviceStateName = _creatingOrderViewModel.DeviceStateSelectedItem;
            _deviceStateService.AddModel(modelState, deviceStateName);
            _creatingOrderViewModel.ModelStateNameItemSorce = _deviceStateService.GetAllModelName(deviceStateName).Result;
            _creatingOrderViewModel.ModelStateSelectedItem = _creatingOrderViewModel.ModelNameComboBox;
        }
    }
}