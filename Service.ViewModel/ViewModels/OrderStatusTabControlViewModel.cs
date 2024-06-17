using MediatR;
using Service.ViewModel.Stores;

namespace Service.ViewModel.ViewModels
{
    public class OrderStatusTabControlViewModel : ViewModelBase
    {
        private readonly OrdersFilter _ordersFilter;
        private readonly OrderStore _orderStore;

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

        public OrderStatusTabControlViewModel(OrdersListingViewModel ordersListingViewModel, OrdersFilter ordersFilter, IMediator mediator, OrderStore orderStore)
        {
            this.ordersListingViewModel = ordersListingViewModel;
            _ordersFilter = ordersFilter;
            _orderStore = orderStore;
            orderStore.ChangeFiltrOrders += OnChangeFiltrOrders;
        }

        private void OnChangeFiltrOrders()
        {
            FiltrStatus = 2;
        }
    }
}