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

        
        private string _description = string.Empty;

        public string DescriptionTextBox
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(DescriptionTextBox));
            }
        }

        private string _toDo = string.Empty;

        public string ToDoTextBox
        {
            get
            {
                return _toDo;
            }
            set
            {
                _toDo = value;
                OnPropertyChanged(nameof(ToDoTextBox));
            }
        }

        private string _accessories = string.Empty;

        public string AccessoriesTexBox
        {
            get
            {
                return _accessories;
            }
            set
            {
                _accessories = value;
                OnPropertyChanged(nameof(AccessoriesTexBox));
            }
        }

       

        public ICommand CreateOrderAndPrintButton { get; }
        public ICommand SaveButton { get; }
        public ICommand CancleButton { get; }

        public CreatingOrderViewModel(IDialogCoordinator dialogCoordinator
                , OrdersListingViewModel ordersListingViewModel
                , IOrderService orderService
                , IDeviceStateService deviceStateService)
        {
            _orderService = orderService;
            _ordersListingViewModel = ordersListingViewModel;


            FlayoutVewModel = new FlayoutVewModel();

            NameOrderViewModel = new NameOrderViewModel(orderService);
            ContactViewModel = new ContactViewModel(this, orderService);
            DeviceViewModel = new DeviceViewModel(deviceStateService, dialogCoordinator, FlayoutVewModel);

            
            SaveButton = new SaveOrderCommand(this, ContactViewModel , DeviceViewModel);
            CancleButton = new CancleCommand(this);

            
        }

        public void Clear()
        {
            ContactViewModel.ContactNameTextBox = string.Empty;
            ContactViewModel.ContactPhoneNumberTextBox = string.Empty;
            DeviceViewModel.DeviceNameComboBox = string.Empty;
            DeviceViewModel.ModelNameComboBox = string.Empty;
            DescriptionTextBox = string.Empty;
            ToDoTextBox = string.Empty;
            AccessoriesTexBox = string.Empty;
            OnPropertyChanged(nameof(NameOrderViewModel));
        }


        public void  SaveOrder()
        {
            CreateOrderDto orderdto = new()
            {
                OrderNo = NameOrderViewModel.OrderNo,
                OrderName = NameOrderViewModel.OrderNameTextBlock,
                ContactName = ContactViewModel.ContactNameTextBox,
                ContactPhoneNumber = ContactViewModel.ContactPhoneNumberTextBox,
                Device = DeviceViewModel.DeviceNameComboBox,
                Model = DeviceViewModel.ModelNameComboBox,
                Description = DescriptionTextBox,
                ToDo = ToDoTextBox,
                Accessories = AccessoriesTexBox
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