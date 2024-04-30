using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands
{
    public class DeleteModelCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        private readonly IDeviceStateService _deviceStateService;

        public DeleteModelCommand(CreatingOrderViewModel creatingOrderViewModel, IDeviceStateService deviceStateService)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _deviceStateService = deviceStateService;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.ModelStateSelectedItem));
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _deviceStateService.DeleteModel(_creatingOrderViewModel.DeviceStateSelectedItem, _creatingOrderViewModel.ModelStateSelectedItem);
            _creatingOrderViewModel.ModelStateSelectedItem = null;
            _creatingOrderViewModel.ModelStateNameItemSorce = _deviceStateService.GetAllModelName(_creatingOrderViewModel.DeviceStateSelectedItem).Result;
        }
    }
}