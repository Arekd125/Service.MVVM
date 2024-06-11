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
        private ObservableCollection<OrderDto> _ordersCollection;
        private readonly OrderStore _orderStore;
        private readonly IMediator _mediator;

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
                SlelectFiltr(FiltrStatus);
            }
        }

        public int EditOrderIndex { get; set; }

        public ICommand EditStatusButton { get; }
        public ICommand DeleteOrderButton { get; }
        public ICommand EditOrderButton { get; }

        public ObservableCollection<OrderDto> OrdersViewModelCollection => _ordersCollection;

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
            _ordersCollection = new ObservableCollection<OrderDto>();
            _orderStore = orderStore;
            _mediator = mediator;
            _dialogCoordinator = dialogCoordinator;

            _orderStore.OrderCreated += OnOrderCreated;
            _orderStore.OrderEdited += OnOrderEdited;

            EditStatusButton = new EditStatusButtonCommand(this);
            EditOrderButton = new EditOrderButtonCommand(this, _orderStore);
            DeleteOrderButton = new DeleteOrderButtonCommand(this);
            LoadOpenOrders();
        }

        private void OnOrderCreated(OrderDto orderDto)
        {
            AddOrder(orderDto);
        }

        public void EditStatusOrder()
        {
            var OrderToEdit = GetOrderByIndex(OrdersViewModelSelectedIndex);
            _ordersCollection[EditOrderIndex].IsFinished = !_ordersCollection[EditOrderIndex].IsFinished;
            _mediator.Send(new EditOrderStatusCommand(OrderToEdit.OrderName));
            SlelectFiltr(FiltrStatus);
        }

        private void OnOrderEdited(OrderDto orderDto)
        {
            var isFinished = _ordersCollection[EditOrderIndex].IsFinished;
            _ordersCollection.RemoveAt(EditOrderIndex);
            orderDto.IsFinished = isFinished;
            _ordersCollection.Insert(EditOrderIndex, orderDto);
        }

        private void AddOrder(OrderDto orderDto)
        {
            _ordersCollection.Insert(0, orderDto);
        }

        private void LoadAllOrders()
        {
            var getAllOrders = _mediator.Send(new GetAllOrdersQuery()).Result;

            foreach (var o in getAllOrders)
            {
                AddOrder(o);
            }
        }

        private void LoadEndOrders()
        {
            var getAllOrders = _mediator.Send(new GetAllOrdersQuery()).Result.Where(o => o.IsFinished == true);

            foreach (var o in getAllOrders)
            {
                AddOrder(o);
            }
        }

        private void LoadOpenOrders()
        {
            var getAllOrders = _mediator.Send(new GetAllOrdersQuery()).Result.Where(o => o.IsFinished == false);

            foreach (var o in getAllOrders)
            {
                AddOrder(o);
            }
        }

        private void SlelectFiltr(int filtr)
        {
            _ordersCollection.Clear();
            if (filtr == 0)
                LoadOpenOrders();
            if (filtr == 1)
                LoadEndOrders();
            if (filtr == 2)
                LoadAllOrders();
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
            var message = $"Imię i Nazwisko: {selectedOrder.ContactName}\nTelefone: {selectedOrder.ContactPhoneNumber}\nMarka i Model: {selectedOrder.Device} {selectedOrder.Model}";

            MessageDialogResult result = await _dialogCoordinator.ShowMessageAsync(
                                            this,
                                            title,
                                            message,
                                            MessageDialogStyle.AffirmativeAndNegative,
                                            mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                DeleteOrder(index);
            }
        }

        public OrderDto GetOrderByIndex(int index)
        {
            return _ordersCollection[index];
        }

        public void DeleteOrder(int index)
        {
            var orderToDelete = GetOrderByIndex(index);
            _ordersCollection.RemoveAt(index);
            _mediator.Send(new DeleteOrderCommand(orderToDelete.OrderName));
        }
    }
}