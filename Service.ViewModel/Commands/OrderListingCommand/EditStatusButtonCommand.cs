using Service.ViewModel.ViewModels;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class EditStatusButtonCommand : CommandBase
    {
        private readonly OrdersListingViewModel _ordersListingViewModel;


        public EditStatusButtonCommand(OrdersListingViewModel ordersListingViewModel)
        {
            _ordersListingViewModel = ordersListingViewModel;

        }
        public override void Execute(object? parameter)
        {
            _ordersListingViewModel.EditStatusOrder();




        }
    }
}
