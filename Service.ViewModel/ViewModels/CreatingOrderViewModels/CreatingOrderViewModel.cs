using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using Service.ViewModel.Commands;
using Service.ViewModel.Commands.CreatingOrderCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Stores;
using Servis.Models.OrderModels;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class CreatingOrderViewModel : ViewModelBase

    {
        private readonly IOrderService _orderService;
        private readonly OrderStore _orderStore;

        public FlyoutVewModel FlyoutVewModel { get; }
        public NameOrderViewModel NameOrderViewModel { get; }
        public ContactViewModel ContactViewModel { get; }
        public DeviceViewModel DeviceViewModel { get; }
        public DescriptionViewModel DescriptionViewModel { get; }

        public ICommand CreateOrderAndPrintButton { get; }
        public ICommand SaveButton { get; }
        public ICommand CancleButton { get; }

        public CreatingOrderViewModel(
            FlyoutVewModel flayoutVewModel,
            NameOrderViewModel nameOrderViewModel,
            ContactViewModel contactViewModel,
            DeviceViewModel deviceViewModel,
            DescriptionViewModel descriptionViewModel,
            OrderStore orderStore,
            IOrderService orderService
            )
        {
            _orderService = orderService;
            _orderStore = orderStore;

            FlyoutVewModel = flayoutVewModel;
            NameOrderViewModel = nameOrderViewModel;
            ContactViewModel = contactViewModel;
            DeviceViewModel = deviceViewModel;
            DescriptionViewModel = descriptionViewModel;

            SaveButton = new SaveOrderCommand(this, ContactViewModel, DeviceViewModel);
            CancleButton = new CancleCommand(this);
        }

        public void Clear()
        {
            DeviceViewModel.DeviceNameComboBox = string.Empty;
            DeviceViewModel.ModelNameComboBox = string.Empty;
            DescriptionViewModel.DescriptionTextBox = string.Empty;
            DescriptionViewModel.ToDoTextBox = string.Empty;
            DescriptionViewModel.AccessoriesTexBox = string.Empty;
            ContactViewModel.RefreshContactsItemSorce();
            ContactViewModel.ClearContacts();
            NameOrderViewModel.SetNextOrderName();
        }

        public void SaveOrder()
        {
            CreateOrderDto orderDto = new()
            {
                OrderNo = NameOrderViewModel.OrderNo,
                OrderName = NameOrderViewModel.OrderNameTextBlock,
                ContactName = ContactViewModel.ContactNameComboBox,
                ContactPhoneNumber = ContactViewModel.ContactPhoneNumberComboBox,
                Device = DeviceViewModel.DeviceNameComboBox,
                Model = DeviceViewModel.ModelNameComboBox,
                ToDo = DescriptionViewModel.ToDoSelectedItems.ToList(),
                Description = DescriptionViewModel.DescriptionTextBox,
                Accessories = DescriptionViewModel.AccessoriesTexBox
            };
            _orderService.CreateOrder(orderDto);

            FlyoutVewModel.ShowFlyout("Dodano zlecenie");
            AddDeviceIfNotExist();
            _orderStore.AddLastOrder();
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