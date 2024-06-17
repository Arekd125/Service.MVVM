using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class DeleteDeviceButtonCommand : CommandBase
    {
        private readonly DeviceViewModel _deviceViewModel;

        public DeleteDeviceButtonCommand(DeviceViewModel deviceViewModel)
        {
            _deviceViewModel = deviceViewModel;
            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return !string.IsNullOrEmpty(_deviceViewModel.DeviceStateSelectedItem);
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