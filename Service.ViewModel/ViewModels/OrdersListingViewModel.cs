using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Queries.GetAllOrders;
using Service.ViewModel.Service.Queries.GetLastOrder;
using Service.ViewModel.Stores;
using System.Collections.ObjectModel;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayOrderDto> _ordersViewModelCollection;
        private readonly OrderStore _orderStore;
        private readonly IMediator _mediator;

        public IEnumerable<DisplayOrderDto> ordersViewModelCollection => _ordersViewModelCollection;

        public OrdersListingViewModel(OrderStore orderStore, IMediator mediator)
        {
            _ordersViewModelCollection = new ObservableCollection<DisplayOrderDto>();
            _orderStore = orderStore;
            _mediator = mediator;
            _orderStore.OrderCreated += OnOrderCreated;

            AllOrders();
        }

        private void OnOrderCreated()
        {
            AddLast();
        }

        public void AddLast()
        {
            var displayOrderDto = _mediator.Send(new GetLastOrderQuery()).Result;

            Add(displayOrderDto);
        }

        private void Add(DisplayOrderDto displayOrderDto)
        {
            _ordersViewModelCollection.Insert(0, displayOrderDto);
        }

        private void AllOrders()
        {
            var getAllOrders = _mediator.Send(new GetAllOrdersQuery()).Result;

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