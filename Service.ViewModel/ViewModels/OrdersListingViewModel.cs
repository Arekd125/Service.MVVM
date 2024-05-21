using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Stores;
using System.Collections.ObjectModel;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayOrderDto> _ordersViewModelCollection;
        private readonly IOrderService _orderService;
        private readonly OrderStore _orderStore;

        public IEnumerable<DisplayOrderDto> ordersViewModelCollection => _ordersViewModelCollection;

        public OrdersListingViewModel(IOrderService orderService, OrderStore orderStore)
        {
            _ordersViewModelCollection = new ObservableCollection<DisplayOrderDto>();
            _orderService = orderService;
            _orderStore = orderStore;
            _orderStore.OrderCreated += OnOrderCreated;

            AllOrders();
        }

        private void OnOrderCreated()
        {
            AddLast();
        }

        public void AddLast()
        {
            var displayOrderDto = _orderService.GetLastOrder().Result;

            Add(displayOrderDto);
        }

        private void Add(DisplayOrderDto displayOrderDto)
        {
            _ordersViewModelCollection.Insert(0, displayOrderDto);
        }

        private void AllOrders()
        {
            var getAllOrders = _orderService.GetAllOrders().Result;

            foreach (var o in getAllOrders)
            {
                Add(o);
            }
        }

        public override void Dispose()
        {
            _orderStore.OrderCreated -= OnOrderCreated;
            base.Dispose();
        }
    }
}