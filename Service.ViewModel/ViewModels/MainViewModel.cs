using Service.ViewModel.Service;

namespace Service.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
    public OrdersListingViewModel ordersListingViewModel { get; set; }
    public CreatingOrderViewModel creatingOrderViewModel { get; set; }

    public MainViewModel(OrdersListingViewModel _ordersListingViewModel, CreatingOrderViewModel _creatingOrderViewModel)
    {
        ordersListingViewModel = _ordersListingViewModel;
        creatingOrderViewModel = _creatingOrderViewModel;
    }
} 