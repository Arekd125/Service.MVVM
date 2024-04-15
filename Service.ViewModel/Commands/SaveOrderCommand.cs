using Service.ViewModel.ViewModels;
using Servis.Models.OrderBuilder;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands
{
    public class SaveOrderCommand : CommandBase
    {
        private readonly ObservableCollection<OrdersViewModel> _ordersViewModel;
        private readonly MainViewModel _mainViewModel;
        private readonly List<Order> _orders;

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_mainViewModel.ContactPhoneNumberTextBox) &&
                    _mainViewModel.ContactPhoneNumberTextBox.Length > 8 &&
                   !string.IsNullOrEmpty(_mainViewModel.DeviceNameComboBox) &&
                   !string.IsNullOrEmpty(_mainViewModel.DeviceModelNameComboBox));
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainViewModel.ContactPhoneNumberTextBox) ||
                e.PropertyName == nameof(MainViewModel.DeviceModelNameComboBox) ||
                e.PropertyName == nameof(MainViewModel.DeviceNameComboBox))

            {
                OnCanExecutedChanged();
            }
        }

        public SaveOrderCommand(MainViewModel mainViewModel, ObservableCollection<OrdersViewModel> ordersViewModel, List<Order> order)
        {
            _ordersViewModel = ordersViewModel;
            _mainViewModel = mainViewModel;
            _orders = order;
            _mainViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            OrderBuilder orderBuilder = new OrderBuilder();
            ContactBuilder contactBuilder = new ContactBuilder(_mainViewModel.ContactNameTextBox, _mainViewModel.ContactPhoneNumberTextBox);
            ModelBuilder modelBuilder = new ModelBuilder(_mainViewModel.DeviceModelNameComboBox);
            DeviceBuilder deviceBuilder = new DeviceBuilder(_mainViewModel.DeviceNameComboBox, modelBuilder.Build());

            orderBuilder.SetContact(contactBuilder.Build())
                .SetDevice(deviceBuilder.Build())
                .SetOrderNo((int)_mainViewModel.OrderNoNumericUpDown)
                .SetStartDate((DateTime)_mainViewModel.StartDateDatePicker)
                .SetDescription(_mainViewModel.DescriptionTextBox)
                .SetToDo(_mainViewModel.ToDoTextBox)
                .SetAccessories(_mainViewModel.AccessoriesTexBox);

            Order order = orderBuilder.Build();

            var OrdersViewModel = new OrdersViewModel(order);
            _ordersViewModel.Add(OrdersViewModel);
            _orders.Add(order);
        }
    }
}