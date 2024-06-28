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
            _ordersListingViewModel.ShowMessage();
        }
    }
}