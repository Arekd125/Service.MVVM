using MahApps.Metro.Controls.Dialogs;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public PanelControlViewModel panelControlViewModel { get; }
    public OrdersListingViewModel ordersListingViewModel { get; }
    public CreatingOrderViewModel creatingOrderViewModel { get; }
    public ToDoListViewModel toDoListViewModel { get; }

    public MainWindowViewModel(OrdersListingViewModel ordersListingViewModel, CreatingOrderViewModel creatingOrderViewModel, ToDoListViewModel toDoListViewModel, PanelControlViewModel panelControlViewModel)
    {
        this.ordersListingViewModel = ordersListingViewModel;
        this.creatingOrderViewModel = creatingOrderViewModel;
        this.toDoListViewModel = toDoListViewModel;
        this.panelControlViewModel = panelControlViewModel;
    }
}