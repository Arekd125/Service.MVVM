using MediatR;
using Service.ViewModel.Commands.OrderListingCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Queries.GetAllOrders;
using Service.ViewModel.Service.Queries.GetLastOrder;
using Service.ViewModel.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayOrderDto> _ordersViewModelCollection;
        private readonly OrderStore _orderStore;
        private readonly IMediator _mediator;
        public ICommand DeleteOrderButton { get; }

        public IEnumerable<DisplayOrderDto> OrdersViewModelCollection => _ordersViewModelCollection;


        private int _ordersViewModelSelectedIndex= -1;

        public int OrdersViewModelSelectedIndex
        {
            get
            {
                return _ordersViewModelSelectedIndex;
            }
            set
            {
                _ordersViewModelSelectedIndex = value;
                OnPropertyChanged(nameof(OrdersViewModelSelectedIndex));
            }
        }


        public void DeleteOrder(int index)
        {
            if(index!=-1)
            _ordersViewModelCollection.RemoveAt(index);
        }


        public OrdersListingViewModel(OrderStore orderStore, IMediator mediator)
        {
            _ordersViewModelCollection = new ObservableCollection<DisplayOrderDto>();
            _orderStore = orderStore;
            _mediator = mediator;
            _orderStore.OrderCreated += OnOrderCreated;

            DeleteOrderButton = new DeleteOrderCommand(this);

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