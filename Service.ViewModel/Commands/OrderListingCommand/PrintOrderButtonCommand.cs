using Service.ViewModel.Service;
using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;
using Service.ViewModel.ViewModels.PrintOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class PrintOrderButtonCommand : CommandBase
    {
        private readonly IPrintDialogService _dialogService;
        private readonly PrintOrderViewModel _printOrderViewModel;
        private readonly OrderStore _orderStore;
        private readonly OrdersListingViewModel _ordersListingViewModel;

        public PrintOrderButtonCommand(IPrintDialogService dialogService, PrintOrderViewModel printOrderViewModel, OrderStore orderStore, OrdersListingViewModel ordersListingViewModel)
        {
            _dialogService = dialogService;
            _printOrderViewModel = printOrderViewModel;
            _orderStore = orderStore;
            _ordersListingViewModel = ordersListingViewModel;
        }

        public override void Execute(object? parameter)
        {
            _ordersListingViewModel.EditOrderIndex = _ordersListingViewModel.OrdersViewModelSelectedIndex;
            var OrderToPrint = _ordersListingViewModel.GetOrderByIndex(_ordersListingViewModel.EditOrderIndex);

            _printOrderViewModel.PrintViewModel.Order = OrderToPrint;
            // _orderStore.OrderToPrint(OrderToPrint);
            _dialogService.ShowDialog(_printOrderViewModel);
        }
    }
}