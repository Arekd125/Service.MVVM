using MediatR;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Queries.GetAllDeviceName;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class AddDeviceButtonCommand : CommandBase
    {
        private readonly DeviceViewModel _deviceViewModel;
        private readonly IMediator _mediator;

        public AddDeviceButtonCommand(DeviceViewModel deviceViewModel, IMediator mediator)
        {
            _deviceViewModel = deviceViewModel;
            _mediator = mediator;

            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return !string.IsNullOrEmpty(_deviceViewModel.DeviceNameComboBox)
                && _deviceViewModel.DeviceNameComboBox.Length > 1
                && string.IsNullOrEmpty(_deviceViewModel.DeviceStateSelectedItem)
                && !IfExists(_deviceViewModel.DeviceNameComboBox.TrimEnd());
        }

        private bool IfExists(string deviceStateName)
        {
            var devices = _mediator.Send(new GetAllDeviceNameQuery()).Result;
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