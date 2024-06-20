using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public PanelControlViewModel panelControlViewModel { get; }
    public CreatingOrderViewModel creatingOrderViewModel { get; }
    public ToDoListViewModel toDoListViewModel { get; }
    public OrderStatusTabControlViewModel orderStatusTabControlViewModel { get; }
    public StatusBarViewModel statusBarViewModel { get; }

    public MainWindowViewModel(OrderStatusTabControlViewModel orderStatusTabControlViewModel, CreatingOrderViewModel creatingOrderViewModel, ToDoListViewModel toDoListViewModel, PanelControlViewModel panelControlViewModel, StatusBarViewModel statusBarViewModel)
    {
        this.creatingOrderViewModel = creatingOrderViewModel;
        this.toDoListViewModel = toDoListViewModel;
        this.panelControlViewModel = panelControlViewModel;
        this.orderStatusTabControlViewModel = orderStatusTabControlViewModel;
        this.statusBarViewModel = statusBarViewModel;
    }
}