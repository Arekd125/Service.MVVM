using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Service.ViewModel.Commands
{
    public class DeleteDeviceCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;
        private readonly IDeviceStateService _deviceStateService;

        public DeleteDeviceCommand(CreatingOrderViewModel creatingOrderViewModel, IDeviceStateService deviceStateService)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _deviceStateService = deviceStateService;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.DeviceStateSelectedItem));
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.ShowMessage();
        }
    }
}