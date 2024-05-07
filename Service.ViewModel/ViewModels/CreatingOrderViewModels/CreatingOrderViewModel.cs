using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using Service.ViewModel.Commands;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class CreatingOrderViewModel : ViewModelBase

    {
        private readonly IOrderService _orderService;
        private readonly OrdersListingViewModel _ordersListingViewModel;

        public FlayoutVewModel FlayoutVewModel { get; }
        public NameOrderViewModel NameOrderViewModel { get; }
        public ContactViewModel ContactViewModel { get; }
        public DeviceViewModel DeviceViewModel { get; }
        public DescriptionViewModel DescriptionViewModel { get; }

        public ICommand CreateOrderAndPrintButton { get; }
        public ICommand SaveButton { get; }
        public ICommand CancleButton { get; }

        public CreatingOrderViewModel(
            FlayoutVewModel flayoutVewModel,
            NameOrderViewModel nameOrderViewModel,
            ContactViewModel contactViewModel,
            DeviceViewModel deviceViewModel,
            DescriptionViewModel descriptionViewModel,
            OrdersListingViewModel ordersListingViewModel,
            IOrderService orderService)
        {
            _orderService = orderService;
            _ordersListingViewModel = ordersListingViewModel;
            FlayoutVewModel = flayoutVewModel;
            NameOrderViewModel = nameOrderViewModel;
            ContactViewModel = contactViewModel;
            DeviceViewModel = deviceViewModel;
            DescriptionViewModel = descriptionViewModel;

            SaveButton = new SaveOrderCommand(this, ContactViewModel, DeviceViewModel);
            CancleButton = new CancleCommand(this);
        }

        public void Clear()
        {
            ContactViewModel.ContactNameComboBox = string.Empty;
            ContactViewModel.ContactNameSelectedItem = string.Empty;
            ContactViewModel.ContactPhoneNumberComboBox = string.Empty;
            ContactViewModel.ContactPhoneNumberSelectedItem = string.Empty;
            DeviceViewModel.DeviceNameComboBox = string.Empty;
            DeviceViewModel.ModelNameComboBox = string.Empty;

            DescriptionViewModel.DescriptionTextBox = string.Empty;
            DescriptionViewModel.ToDoTextBox = string.Empty;
            DescriptionViewModel.AccessoriesTexBox = string.Empty;
            // ContactViewModel.RefreshContacts();
            NameOrderViewModel.SetNextOrderName();
        }

        public void SaveOrder()
        {
            CreateOrderDto orderdto = new()
            {
                OrderNo = NameOrderViewModel.OrderNo,
                OrderName = NameOrderViewModel.OrderNameTextBlock,
                ContactName = ContactViewModel.ContactNameComboBox,
                ContactPhoneNumber = ContactViewModel.ContactPhoneNumberComboBox,
                Device = DeviceViewModel.DeviceNameComboBox,
                Model = DeviceViewModel.ModelNameComboBox,
                Description = DescriptionViewModel.DescriptionTextBox,
                ToDo = DescriptionViewModel.ToDoTextBox,
                Accessories = DescriptionViewModel.AccessoriesTexBox
            };

            _orderService.CreateOrder(orderdto);
            FlayoutVewModel.ShowFlyout("Dodano Zlecenie");
            AddDeviceIfNotExist();
            _ordersListingViewModel.AddLast();
            Clear();
        }

        private void AddDeviceIfNotExist()
        {
            if (string.IsNullOrEmpty(DeviceViewModel.DeviceStateSelectedItem))
            {
                DeviceViewModel.SaveDeviceState();
            }

            if (string.IsNullOrEmpty(DeviceViewModel.ModelStateSelectedItem))
            {
                DeviceViewModel.SaveModelState();
            }
        }
    }
}