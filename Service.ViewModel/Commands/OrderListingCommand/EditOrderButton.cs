using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class EditOrderButton : CommandBase
    {
        private readonly OrdersListingViewModel _ordersListingViewModel;
        private readonly OrderStore _orderStore;

        public EditOrderButton(OrdersListingViewModel ordersListingViewModel, OrderStore orderStore)
        {
            _ordersListingViewModel = ordersListingViewModel;
            _orderStore = orderStore;
        }

        public override void Execute(object? parameter)
        {
            //var index = _ordersListingViewModel.OrdersViewModelSelectedIndex;
            //if (index != -1)
            //{
            //    _ordersListingViewModel.ShowMessage(index);
            //    _ordersListingViewModel.OrdersViewModelSelectedIndex = -1;
            //}
            var index = _ordersListingViewModel.OrdersViewModelSelectedIndex;
            var OrderToEdit = _ordersListingViewModel.GetOrderByIndex(index);
            _orderStore.EditOrder(OrderToEdit.OrderName);
        }
    }
}