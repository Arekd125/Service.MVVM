using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class DeleteModelButtonCommand : CommandBase
    {
        private readonly DeviceViewModel _deviceViewModel;



        public DeleteModelButtonCommand(DeviceViewModel deviceViewModel)
        {
            _deviceViewModel = deviceViewModel;
            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return !string.IsNullOrEmpty(_deviceViewModel.ModelStateSelectedItem);
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _deviceViewModel.DeleteModel();



        }
    }
}