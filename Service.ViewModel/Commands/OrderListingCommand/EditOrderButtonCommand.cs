using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class EditOrderButtonCommand : CommandBase
    {
        private readonly OrdersListingViewModel _ordersListingViewModel;
        private readonly OrderStore _orderStore;

        public EditOrderButtonCommand(OrdersListingViewModel ordersListingViewModel, OrderStore orderStore)
        {
            _ordersListingViewModel = ordersListingViewModel;
            _orderStore = orderStore;
        }

        public override void Execute(object? parameter)
        {
          
            var index = _ordersListingViewModel.OrdersViewModelSelectedIndex;
            var OrderToEdit = _ordersListingViewModel.GetOrderByIndex(index);
            _orderStore.EditOrder(OrderToEdit);
        }
    }
}