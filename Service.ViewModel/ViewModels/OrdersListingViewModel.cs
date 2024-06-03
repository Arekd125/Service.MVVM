using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
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
        public IDialogCoordinator _dialogCoordinator;
        private ObservableCollection<DisplayOrderDto> _ordersViewModelCollection;
        private readonly OrderStore _orderStore;
        private readonly IMediator _mediator;
        public ICommand DeleteOrderButton { get; }

        public IEnumerable<DisplayOrderDto> OrdersViewModelCollection => _ordersViewModelCollection;

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

        public OrdersListingViewModel(OrderStore orderStore, IMediator mediator, IDialogCoordinator dialogCoordinator)
        {
            _ordersViewModelCollection = new ObservableCollection<DisplayOrderDto>();
            _orderStore = orderStore;
            _mediator = mediator;
            _orderStore.OrderCreated += OnOrderCreated;
            _dialogCoordinator = dialogCoordinator;
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

        private DisplayOrderDto GetOrderByIndex(int index)
        {
            return _ordersViewModelCollection[index];
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

        public void DeleteOrder(int index, string OrderName)
        {
            _ordersViewModelCollection.RemoveAt(index);
            _mediator.Send(new Service.Commands.DeleteOrder.DeleteOrderCommand(OrderName));
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
    }
}