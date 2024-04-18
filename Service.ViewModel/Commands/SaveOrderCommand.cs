using Service.Model.Services;
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
        private readonly CreatingOrderViewModel _creatingOrderViewModel;
        private readonly DatabaseOrderCreator _orderCreator;
        private readonly OrdersListingViewModel _ordersListingViewModel;

        public SaveOrderCommand(CreatingOrderViewModel creatingOrderViewModel, DatabaseOrderCreator orderCreator, OrdersListingViewModel ordersListingViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _orderCreator = orderCreator;
            _ordersListingViewModel = ordersListingViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.ContactPhoneNumberTextBox) &&
                    _creatingOrderViewModel.ContactPhoneNumberTextBox.Length > 8 &&
                   !string.IsNullOrEmpty(_creatingOrderViewModel.DeviceNameComboBox) &&
                   !string.IsNullOrEmpty(_creatingOrderViewModel.DeviceModelNameComboBox));
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatingOrderViewModel.ContactPhoneNumberTextBox) ||
                e.PropertyName == nameof(CreatingOrderViewModel.DeviceModelNameComboBox) ||
                e.PropertyName == nameof(CreatingOrderViewModel.DeviceNameComboBox))

            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            OrderBuilder orderBuilder = new OrderBuilder();
            ContactBuilder contactBuilder = new ContactBuilder(_creatingOrderViewModel.ContactNameTextBox, _creatingOrderViewModel.ContactPhoneNumberTextBox);

            orderBuilder.SetContact(contactBuilder.Build())
                .SetDevice(_creatingOrderViewModel.DeviceNameComboBox)
                .SetModel(_creatingOrderViewModel.DeviceModelNameComboBox)
                .SetOrderNo((int)_creatingOrderViewModel.OrderNoNumericUpDown)
                .SetStartDate((DateTime)_creatingOrderViewModel.StartDateDatePicker)
                .SetDescription(_creatingOrderViewModel.DescriptionTextBox)
                .SetToDo(_creatingOrderViewModel.ToDoTextBox)
                .SetAccessories(_creatingOrderViewModel.AccessoriesTexBox);

            Order order = orderBuilder.Build();
            _orderCreator.CreateOrder(order);
            _ordersListingViewModel.Add(order);
            _creatingOrderViewModel.Clear();
        }
    }
}