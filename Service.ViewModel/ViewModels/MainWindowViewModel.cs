using MahApps.Metro.Controls.Dialogs;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public OrdersListingViewModel ordersListingViewModel { get; }
    public CreatingOrderViewModel creatingOrderViewModel { get; }
    public ToDoListViewModel toDoListViewModel { get; }
    public OrderDetailsViewModel orderDetailsViewModel { get; }

    public MainWindowViewModel(OrdersListingViewModel ordersListingViewModel, CreatingOrderViewModel creatingOrderViewModel, ToDoListViewModel toDoListViewModel, OrderDetailsViewModel orderDetailsViewModel)
    {
        this.ordersListingViewModel = ordersListingViewModel;
        this.creatingOrderViewModel = creatingOrderViewModel;
        this.toDoListViewModel = toDoListViewModel;
        this.orderDetailsViewModel = orderDetailsViewModel;
    }
}