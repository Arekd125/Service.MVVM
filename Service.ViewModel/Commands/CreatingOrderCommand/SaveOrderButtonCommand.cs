using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class SaveOrderButtonCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;
        private readonly ContactViewModel _contactViewModel;
        private readonly DeviceViewModel _deviceViewModel;

        public SaveOrderButtonCommand(CreatingOrderViewModel creatingOrderViewModel, ContactViewModel contactViewModel, DeviceViewModel deviceViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _contactViewModel = contactViewModel;
            _deviceViewModel = deviceViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _contactViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }

        private bool CanExecuteValidator()
        {
            return !string.IsNullOrEmpty(_contactViewModel.ContactPhoneNumberComboBox) &&
                    _contactViewModel.ContactPhoneNumberComboBox.Length > 10 &&
                   !string.IsNullOrEmpty(_deviceViewModel.DeviceNameComboBox) &&
                   !string.IsNullOrEmpty(_deviceViewModel.ModelNameComboBox);
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.SaveOrder();
        }
    }
}