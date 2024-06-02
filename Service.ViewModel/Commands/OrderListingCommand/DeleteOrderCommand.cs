using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class DeleteOrderCommand : CommandBase
    {
        private readonly OrdersListingViewModel _ordersListingViewModel;

        public DeleteOrderCommand(OrdersListingViewModel ordersListingViewModel)
        {
            _ordersListingViewModel = ordersListingViewModel;
        }
        public override void Execute(object? parameter)
        {

            var index = _ordersListingViewModel.OrdersViewModelSelectedIndex;
            _ordersListingViewModel.DeleteOrder(index);
            _ordersListingViewModel.OrdersViewModelSelectedIndex = -1;

        }
    }
}
