using AutoMapper;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using MediatR;
using Service.ViewModel.Commands.OrderListingCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Commands.DeleteOrder;
using Service.ViewModel.Service.Commands.EditOrderStatus;
using Service.ViewModel.Service.Queries.GetAllOrders;
using Service.ViewModel.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel : ViewModelBase
    {
        public IDialogCoordinator _dialogCoordinator;
        private ObservableCollection<OrderDto> _ordersViewModelCollection;
        private readonly OrderStore _orderStore;
        private readonly IMediator _mediator;

        public int EditOrderIndex { get; set; }

        public ICommand EditStatusButton { get; }
        public ICommand DeleteOrderButton { get; }
        public ICommand EditOrderButton { get; }

        public ObservableCollection<OrderDto> OrdersViewModelCollection => _ordersViewModelCollection;

        private int _ordersViewModelSelectedIndex = -1;

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

        public OrdersListingViewModel(OrderStore orderStore, IMediator mediator, IDialogCoordinator dialogCoordinator, IMapper mapper)
        {
            _ordersViewModelCollection = new ObservableCollection<OrderDto>();
            _orderStore = orderStore;
            _mediator = mediator;
            _orderStore.OrderCreated += OnOrderCreated;
            _orderStore.OrderEdited += OnOrderEdited;
            _dialogCoordinator = dialogCoordinator;
            EditStatusButton = new EditStatusButtonCommand(this);
            EditOrderButton = new EditOrderButtonCommand(this, _orderStore);
            DeleteOrderButton = new DeleteOrderButtonCommand(this);
            AllOrders();
        }

        private void OnOrderCreated(OrderDto orderDto)
        {
            Add(orderDto);
        }

        public void EditStatusOrder()
        {
          
            var OrderToEdit = GetOrderByIndex(OrdersViewModelSelectedIndex);
           _ordersViewModelCollection[EditOrderIndex].IsFinished = !_ordersViewModelCollection[EditOrderIndex].IsFinished;
            _mediator.Send(new EditOrderStatusCommand(OrderToEdit.OrderName));
          
        }

        private void OnOrderEdited(OrderDto orderDto)
        {
           var isFinished = _ordersViewModelCollection[EditOrderIndex].IsFinished;
            _ordersViewModelCollection.RemoveAt(EditOrderIndex);
            orderDto.IsFinished = isFinished;
            _ordersViewModelCollection.Insert(EditOrderIndex, orderDto);
        }

        private void Add(OrderDto orderDto)
        {
            _ordersViewModelCollection.Insert(0, orderDto);
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
            _orderStore.OrderEdited -= OnOrderEdited;
            base.Dispose();
        }

        public async void ShowMessage(int index)
        {
            var themes = ThemeManager.Current.DetectTheme().Resources;
            themes["Theme.ThemeInstance"] = ThemeManager.Current.GetTheme("Light.Red");

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Tak",
                NegativeButtonText = "Anuluj",
                CustomResourceDictionary = themes,
                ColorScheme = MetroDialogColorScheme.Accented
            };
            var selectedOrder = GetOrderByIndex(index);
            var title = $"Usunąć Zlecenie {selectedOrder.OrderName}?";
            //  var models = string.Join(", ", ModelStateNameItemSorce);
            var message = $"Imię i Nazwisko: {selectedOrder.ContactName}\nTelefone: {selectedOrder.ContactPhoneNumber}\nMarka i Model: {selectedOrder.Device} {selectedOrder.Model}";

            MessageDialogResult result = await _dialogCoordinator.ShowMessageAsync(
                                            this,
                                            title,
                                            message,
                                            MessageDialogStyle.AffirmativeAndNegative,
                                            mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                DeleteOrder(index, selectedOrder.OrderName);
            }
        }

        public OrderDto GetOrderByIndex(int index)
        {
            return _ordersViewModelCollection[index];
        }

        public void DeleteOrder(int index, string OrderName)
        {
            _ordersViewModelCollection.RemoveAt(index);
            _mediator.Send(new DeleteOrderCommand(OrderName));
        }
    }
}