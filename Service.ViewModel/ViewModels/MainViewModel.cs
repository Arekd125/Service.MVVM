using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
    public OrdersListingViewModel ordersListingViewModel { get; }
    public CreatingOrderViewModel creatingOrderViewModel { get;  }

    public MainViewModel(OrdersListingViewModel _ordersListingViewModel, CreatingOrderViewModel _creatingOrderViewModel)
    {
        ordersListingViewModel = _ordersListingViewModel;
        creatingOrderViewModel = _creatingOrderViewModel;
    }
} 