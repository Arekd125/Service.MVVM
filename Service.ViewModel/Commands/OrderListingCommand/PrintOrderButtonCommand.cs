using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;
using Service.ViewModel.ViewModels.PrintOrderViewModels;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class PrintOrderButtonCommand : CommandBase
    {
        private readonly IDialogService _dialogService;
        private readonly PrintOrderViewModel _printOrderViewModel;
        private readonly OrdersListingViewModel _ordersListingViewModel;

        public PrintOrderButtonCommand(IDialogService dialogService, PrintOrderViewModel printOrderViewModel, OrdersListingViewModel ordersListingViewModel)
        {
            _dialogService = dialogService;
            _printOrderViewModel = printOrderViewModel;
            _ordersListingViewModel = ordersListingViewModel;
        }

        public override void Execute(object? parameter)
        {
            var OrderToPrint = _ordersListingViewModel.OrdersViewModelSelectedItem;

            _printOrderViewModel.PrintViewModel.Order = OrderToPrint;
            _dialogService.ShowDialog(_printOrderViewModel);
        }
    }
}