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
        private readonly DeviceViewModel _deviceViewModel;

        public DeleteDeviceCommand(DeviceViewModel deviceViewModel)
        {
            _deviceViewModel = deviceViewModel;
            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_deviceViewModel.DeviceStateSelectedItem));
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_deviceViewModel.ModelStateNameItemSorce.Count() != 0)
            {
                _deviceViewModel.ShowMessage();
            }
            else
            {
                _deviceViewModel.DeleteDeviceAndModels();
            }
        }
    }
}