using Service.Model.Services.ServicesDevice;
using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;
using Servis.Models.OrderBuilder;
using Servis.Models.OrderModels;
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
        private readonly ServiceDeviceState _serviceDeviceState;
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public AddDeviceCommand(CreatingOrderViewModel creatingOrderViewModel, ServiceDeviceState serviceDeviceState)
        {
            _serviceDeviceState = serviceDeviceState;
            _creatingOrderViewModel = creatingOrderViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.DeviceNameComboBox)) && _creatingOrderViewModel.DeviceNameComboBox.Length > 1
                && (_creatingOrderViewModel.DeviceStateSelectedItem == null) && !IfExist(_creatingOrderViewModel.DeviceNameComboBox);
        }

        private bool IfExist(string deviceName)
        {
            var devices = _serviceDeviceState.GetAllDeviceName();
            return devices.Any(p => p == deviceName);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatingOrderViewModel.DeviceStateNameComboBox) ||
                e.PropertyName == nameof(CreatingOrderViewModel.DeviceStateSelectedItem) ||
                e.PropertyName == nameof(CreatingOrderViewModel.DeviceNameComboBox) ||
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

            DeviceState deviceState = deviceStateBuilder.Build();
            _serviceDeviceState.CreateDevice(deviceState);
            _creatingOrderViewModel.DeviceStateNameComboBox = _serviceDeviceState.GetAllDeviceName();
        }
    }
}