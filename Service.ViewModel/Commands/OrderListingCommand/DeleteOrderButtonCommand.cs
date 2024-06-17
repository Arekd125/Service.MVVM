using Service.ViewModel.ViewModels;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class DeleteOrderButtonCommand : CommandBase
    {
        private readonly OrdersListingViewModel _ordersListingViewModel;

        public DeleteOrderButtonCommand(OrdersListingViewModel ordersListingViewModel)
        {
            _ordersListingViewModel = ordersListingViewModel;
        }

        public override void Execute(object? parameter)
        {
            var index = _ordersListingViewModel.OrdersViewModelSelectedIndex;
            if (index != -1)
            {

                _ordersListingViewModel.ShowMessage(index);
                _ordersListingViewModel.OrdersViewModelSelectedIndex = -1;
            }
        }
    }
}