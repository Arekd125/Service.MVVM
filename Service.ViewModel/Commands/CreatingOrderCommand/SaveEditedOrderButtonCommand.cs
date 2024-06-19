using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class SaveEditedOrderButtonCommand : SaveOrderButtonCommand
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public SaveEditedOrderButtonCommand(CreatingOrderViewModel creatingOrderViewModel,
            ContactViewModel contactViewModel,
            DeviceViewModel deviceViewModel, DescriptionViewModel descriptionViewModel) :
            base(creatingOrderViewModel, contactViewModel, deviceViewModel, descriptionViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.EditOrder();
        }
    }
}