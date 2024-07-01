using AutoMapper;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using MediatR;
using Service.ViewModel.Commands.CreatingOrderCommand;
using Service.ViewModel.Commands.OrderListingCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Commands.DeleteOrder;
using Service.ViewModel.Service.Commands.EditOrderStatus;
using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels.PrintOrderViewModels;
using Service.ViewModel.Stores.OrdersFilter;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel : ViewModelBase
    {
        public IDialogCoordinator _dialogCoordinator;
        private ObservableCollection<OrderDto> _ordersCollection;
        private readonly OrderStore _orderStore;
        private readonly OrdersFilter _ordersFilter;
        private readonly IMediator _mediator;

        public ICommand EditStatusButton { get; }
        public ICommand PrintOrderButton { get; }
        public ICommand EditOrderButton { get; }
        public ICommand DeleteOrderButton { get; }

        public ObservableCollection<OrderDto> OrdersViewModelCollection => _ordersCollection;

        private OrderDto _ordersViewModelSelectedItem;

        public OrderDto OrdersViewModelSelectedItem
        {
            get
            {
                return _ordersViewModelSelectedItem;
            }
            set
            {
                _ordersViewModelSelectedItem = value;
                OnPropertyChanged(nameof(OrdersViewModelSelectedItem));
            }
        }

        public OrdersListingViewModel(OrderStore orderStore, IMediator mediator, IDialogCoordinator dialogCoordinator, IMapper mapper, OrdersFilter ordersFilter, IDialogService dialogService, PrintOrderViewModel printOrderViewModel)
        {
            _ordersCollection = new ObservableCollection<OrderDto>();
            _orderStore = orderStore;
            _mediator = mediator;
            _dialogCoordinator = dialogCoordinator;
            _ordersFilter = ordersFilter;

            _orderStore.OrderCreated += OnOrderCreated;
            _orderStore.OrderEdited += OnOrderEdited;
            _orderStore.FiltringChanged += OnFiltringChanged;

            EditStatusButton = new EditStatusButtonCommand(this);
            PrintOrderButton = new PrintOrderButtonCommand(dialogService, printOrderViewModel, this);
            EditOrderButton = new EditOrderButtonCommand(this, _orderStore);
            DeleteOrderButton = new DeleteOrderButtonCommand(this);

            var OrderToLoad = _ordersFilter.SendOrderDtos();
            LoadOrders(OrderToLoad);
        }

        private void OnOrderEdited(OrderDto orderDto)
        {
            var isFinished = OrdersViewModelSelectedItem.IsFinished;
            _ordersCollection.Remove(OrdersViewModelSelectedItem);
            orderDto.IsFinished = isFinished;
            orderDto.StartDate = DateTime.Now;
            _ordersCollection.Add(orderDto);
        }

        private void OnOrderCreated(OrderDto orderDto)
        {
            AddOrder(orderDto);
            OnFiltringChanged();
        }

        private void OnFiltringChanged()
        {
            var OrderToLoad = _ordersFilter.SendOrderDtos();
            LoadOrders(OrderToLoad);
        }

        public void EditStatusOrder()
        {
            var OrderToEdit = _ordersViewModelSelectedItem;
            OrdersViewModelSelectedItem.IsFinished = !OrdersViewModelSelectedItem.IsFinished;
            _mediator.Send(new EditOrderStatusCommand(OrderToEdit.OrderName));
            var OrderToLoad = _ordersFilter.SendOrderDtos();
            LoadOrders(OrderToLoad);
        }

        private void AddOrder(OrderDto orderDto)
        {
            _ordersCollection.Add(orderDto);
        }

        public void LoadOrders(IEnumerable<OrderDto> orderDtos)
        {
            _ordersCollection.Clear();

            foreach (var o in orderDtos)
            {
                AddOrder(o);
            }
        }

        public override void Dispose()
        {
            _orderStore.OrderCreated -= OnOrderCreated;
            _orderStore.OrderEdited -= OnOrderEdited;
            _orderStore.FiltringChanged -= OnFiltringChanged;
            base.Dispose();
        }

        public async void ShowMessage()
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
            var selectedOrder = _ordersViewModelSelectedItem;
            var title = $"Usunąć Zlecenie {selectedOrder.OrderName}?";
            var message = $"Imię i Nazwisko: {selectedOrder.ContactName}\nTelefone: {selectedOrder.ContactPhoneNumber}\nMarka i Model: {selectedOrder.Device} {selectedOrder.Model}";

            MessageDialogResult result = await _dialogCoordinator.ShowMessageAsync(
                                            this,
                                            title,
                                            message,
                                            MessageDialogStyle.AffirmativeAndNegative,
                                            mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                DeleteOrder(_ordersViewModelSelectedItem);
            }
        }

        public void DeleteOrder(OrderDto orderToDelete)
        {
            _ordersCollection.Remove(orderToDelete);

            _mediator.Send(new DeleteOrderCommand(orderToDelete.OrderName));
        }
    }
}