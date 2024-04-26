using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;

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
        private readonly IOrderService _orderService;
        private readonly OrdersListingViewModel _ordersListingViewModel;

        public SaveOrderCommand(CreatingOrderViewModel creatingOrderViewModel, IOrderService orderService, OrdersListingViewModel ordersListingViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _orderService = orderService;
            _ordersListingViewModel = ordersListingViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.ContactPhoneNumberTextBox) &&
                    _creatingOrderViewModel.ContactPhoneNumberTextBox.Length > 10 &&
                   !string.IsNullOrEmpty(_creatingOrderViewModel.DeviceNameComboBox) &&
                   !string.IsNullOrEmpty(_creatingOrderViewModel.ModelNameComboBox));
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatingOrderViewModel.ContactPhoneNumberTextBox) ||
                e.PropertyName == nameof(CreatingOrderViewModel.ModelNameComboBox) ||
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
            CreateOrderDto orderdto = new CreateOrderDto()
            {
                OrderNo = _creatingOrderViewModel.OrderNo,
                OrderName = _creatingOrderViewModel.OrderNameTextBlock,
                ContactName = _creatingOrderViewModel.ContactNameTextBox,
                ContactPhoneNumber = _creatingOrderViewModel.ContactPhoneNumberTextBox,
                Device = _creatingOrderViewModel.DeviceNameComboBox,
                Model = _creatingOrderViewModel.ModelNameComboBox,
                Description = _creatingOrderViewModel.DescriptionTextBox,
                ToDo = _creatingOrderViewModel.ToDoTextBox,
                Accessories = _creatingOrderViewModel.AccessoriesTexBox
            };

            _orderService.CreateOrder(orderdto);
            _ordersListingViewModel.AddLast();
            _creatingOrderViewModel.Clear();
        }
    }
}