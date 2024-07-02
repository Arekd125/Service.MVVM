using Service.ViewModel.Stores;
using Service.ViewModel.Stores.OrdersFilter;

namespace Service.ViewModel.ViewModels
{
    public class OrderStatusTabControlViewModel : ViewModelBase
    {
        private readonly OrdersFilter _ordersFilter;

        private int _filtrStatus;

        public int FiltrStatus
        {
            get
            {
                return _filtrStatus;
            }
            set
            {
                _filtrStatus = value;
                OnPropertyChanged(nameof(FiltrStatus));
                _ordersFilter.SelectFiltr(FiltrStatus);
            }
        }

        public OrdersListingViewModel ordersListingViewModel { get; }

        public OrderStatusTabControlViewModel(OrdersListingViewModel ordersListingViewModel, OrdersFilter ordersFilter, OrderStore orderStore)
        {
            this.ordersListingViewModel = ordersListingViewModel;
            _ordersFilter = ordersFilter;
            orderStore.ChangeFiltrOrders += OnChangeFiltrOrders;
        }

        private void OnChangeFiltrOrders()
        {
            FiltrStatus = 2;
        }
    }
}