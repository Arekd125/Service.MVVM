using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using Service.ViewModel.ViewModels.PrintOrderViewModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class PrintButtonCommand : SaveOrderButtonCommand
    {
        private readonly IPrintDialogService _dialogService;
        private readonly PrintOrderViewModel _printOrderViewModel;
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public PrintButtonCommand(CreatingOrderViewModel creatingOrderViewModel,
            ContactViewModel contactViewModel,
            DeviceViewModel deviceViewModel,
            IPrintDialogService dialogService,
            PrintOrderViewModel printOrderViewModel,
            DescriptionViewModel descriptionViewModel) :
            base(creatingOrderViewModel, contactViewModel, deviceViewModel, descriptionViewModel)
        {
            _dialogService = dialogService;
            _printOrderViewModel = printOrderViewModel;
            _creatingOrderViewModel = creatingOrderViewModel;
        }

        public override void Execute(object? parameter)
        {
            var OrderToPrint = _creatingOrderViewModel.CreateOrderDto();
            _printOrderViewModel.PrintViewModel.Order = OrderToPrint;

            _dialogService.ShowDialog(_printOrderViewModel);
        }
    }
}