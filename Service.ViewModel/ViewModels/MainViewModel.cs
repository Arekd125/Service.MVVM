using Service.ViewModel.Service;

namespace Service.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
    public OrdersListingViewModel ordersListingViewModel { get; set; }
    public CreatingOrderViewModel creatingOrderViewModel { get; set; }

    public MainViewModel(IOrderService orderService, IDeviceStateService deviceStateService)
    {
        ordersListingViewModel = new OrdersListingViewModel(orderService);
        creatingOrderViewModel = new CreatingOrderViewModel(ordersListingViewModel, orderService, deviceStateService);
    }
}