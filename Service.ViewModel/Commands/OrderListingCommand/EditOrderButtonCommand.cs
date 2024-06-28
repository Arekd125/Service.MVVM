using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;

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
            var OrderToEdit = _ordersListingViewModel.OrdersViewModelSelectedItem;
            _orderStore.OrderToEdit(OrderToEdit);
        }
    }
}