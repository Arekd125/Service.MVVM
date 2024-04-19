using Service.Model.Services.ServicesDevice;
using Service.ViewModel.ViewModels;
using Servis.Models.OrderBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands
{
    public class AddDeviceCommand : CommandBase
    {
        private readonly IDeviceCreator _deviceCreator;
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public AddDeviceCommand(CreatingOrderViewModel creatingOrderViewModel, IDeviceCreator deviceCreator)
        {
            _deviceCreator = deviceCreator;
            _creatingOrderViewModel = creatingOrderViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.DeviceNameComboBox)) && _creatingOrderViewModel.DeviceNameComboBox.Length > 1
                && (_creatingOrderViewModel.DeviceStateSelectedItem == null);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatingOrderViewModel.DeviceNameComboBox) ||
                e.PropertyName == nameof(CreatingOrderViewModel.DeviceModelNameComboBox))

            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            DeviceStateBuilder deviceStateBuilder = new DeviceStateBuilder(_creatingOrderViewModel.DeviceNameComboBox);

            _deviceCreator.CreateDevice(deviceStateBuilder.Build());
        }
    }
}