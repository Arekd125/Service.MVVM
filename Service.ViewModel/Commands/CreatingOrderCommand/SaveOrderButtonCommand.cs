using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class SaveOrderButtonCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;
        private readonly ContactViewModel _contactViewModel;
        private readonly DeviceViewModel _deviceViewModel;
        private readonly DescriptionViewModel _descriptionViewModel;

        public SaveOrderButtonCommand(CreatingOrderViewModel creatingOrderViewModel, ContactViewModel contactViewModel, DeviceViewModel deviceViewModel, DescriptionViewModel descriptionViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _contactViewModel = contactViewModel;
            _deviceViewModel = deviceViewModel;
            _descriptionViewModel = descriptionViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _contactViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _deviceViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _descriptionViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return !string.IsNullOrEmpty(_contactViewModel.ContactPhoneNumberComboBox) &&
                    _contactViewModel.ContactPhoneNumberComboBox.Length > 10 &&
                   !string.IsNullOrEmpty(_deviceViewModel.DeviceNameComboBox) &&
                   !string.IsNullOrEmpty(_deviceViewModel.ModelNameComboBox) &&
                   (!string.IsNullOrEmpty(_descriptionViewModel.DescriptionTextBox) ||
                    !string.IsNullOrEmpty(_descriptionViewModel.AccessoriesTexBox) ||
                     _descriptionViewModel.SelectedIndex != -1);
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