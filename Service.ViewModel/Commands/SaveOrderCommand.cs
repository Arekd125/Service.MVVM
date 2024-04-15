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
        private readonly List<Order> _orders;

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

        public SaveOrderCommand(CreatingOrderViewModel creatingOrderViewModel, List<Order> order)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _orders = order;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            OrderBuilder orderBuilder = new OrderBuilder();
            ContactBuilder contactBuilder = new ContactBuilder(_creatingOrderViewModel.ContactNameTextBox, _creatingOrderViewModel.ContactPhoneNumberTextBox);
            ModelBuilder modelBuilder = new ModelBuilder(_creatingOrderViewModel.DeviceModelNameComboBox);
            DeviceBuilder deviceBuilder = new DeviceBuilder(_creatingOrderViewModel.DeviceNameComboBox, modelBuilder.Build());

            orderBuilder.SetContact(contactBuilder.Build())
                .SetDevice(deviceBuilder.Build())
                .SetOrderNo((int)_creatingOrderViewModel.OrderNoNumericUpDown)
                .SetStartDate((DateTime)_creatingOrderViewModel.StartDateDatePicker)
                .SetDescription(_creatingOrderViewModel.DescriptionTextBox)
                .SetToDo(_creatingOrderViewModel.ToDoTextBox)
                .SetAccessories(_creatingOrderViewModel.AccessoriesTexBox);

            Order order = orderBuilder.Build();
            _orders.Add(order);
        }
    }
}