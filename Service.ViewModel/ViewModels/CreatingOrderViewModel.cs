using Microsoft.Extensions.DependencyInjection;
using Service.Model.Migrations;
using Service.Model.Repositories;

using Service.ViewModel.Commands;
using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Service.ViewModel.ViewModels
{
    public class CreatingOrderViewModel : ViewModelBase

    {
        private readonly IOrderService _orderService;
        private readonly IDeviceStateService _deviceStateService;

        private IEnumerable<string> _deviceStateNameItemsSource;

        public IEnumerable<string> DeviceStateNameItemsSource
        {
            get
            {
                _deviceStateNameItemsSource = _deviceStateService.GetAllDeviceName().Result;
                return _deviceStateNameItemsSource;
            }
            set
            {
                _deviceStateNameItemsSource = value;
                OnPropertyChanged(nameof(DeviceStateNameItemsSource));
            }
        }

        private IEnumerable<string> _modelStateNameItemSorceComboBox;

        public IEnumerable<string> ModelStateNameItemSorce
        {
            get
            {
                return _modelStateNameItemSorceComboBox;
            }
            set
            {
                _modelStateNameItemSorceComboBox = value;
                OnPropertyChanged(nameof(ModelStateNameItemSorce));
            }
        }

        private string _deviceStateSelectedItem;

        public string DeviceStateSelectedItem
        {
            get
            {
                return _deviceStateSelectedItem;
            }
            set
            {
                _deviceStateSelectedItem = value;
                OnPropertyChanged(nameof(DeviceStateSelectedItem));
                ModelStateNameItemSorce = _deviceStateService.GetAllModelName(DeviceStateSelectedItem).Result;
            }
        }

        private string _modelStateSelectedItem;

        public string ModelStateSelectedItem
        {
            get
            {
                return _modelStateSelectedItem;
            }
            set
            {
                _modelStateSelectedItem = value;
                OnPropertyChanged(nameof(ModelStateSelectedItem));
            }
        }

        private int _orderNo;

        public int OrderNo
        {
            get
            {
                return _orderNo;
            }
            set
            {
                _orderNo = value;
                OnPropertyChanged(nameof(OrderNo));
            }
        }

        private string _OrderName;

        public string OrderNameTextBlock
        {
            get
            {
                _OrderName = SetOrderName();
                return _OrderName;
            }
            set
            {
                _OrderName = value;
                OnPropertyChanged(nameof(OrderNameTextBlock));
            }
        }

        private string _contactName;

        public string ContactNameTextBox
        {
            get
            {
                return _contactName;
            }
            set
            {
                _contactName = value;
                OnPropertyChanged(nameof(ContactNameTextBox));
            }
        }

        private string _contactPhoneNumber;

        public string ContactPhoneNumberTextBox
        {
            get
            {
                return _contactPhoneNumber;
            }
            set
            {
                _contactPhoneNumber = PhoneValisation(value);

                OnPropertyChanged(nameof(ContactPhoneNumberTextBox));
            }
        }

        private string _deviceName;

        public string DeviceNameComboBox
        {
            get
            {
                return _deviceName;
            }
            set
            {
                _deviceName = value;
                OnPropertyChanged(nameof(DeviceNameComboBox));
            }
        }

        private string _ModelName;

        public string ModelNameComboBox
        {
            get
            {
                return _ModelName;
            }
            set
            {
                _ModelName = value;
                OnPropertyChanged(nameof(ModelNameComboBox));
            }
        }

        private string _description;

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

        private string _toDo;

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

        private string _accessories;

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

        public ICommand AddDeviceButton { get; }
        public ICommand DeleteDeviceButton { get; }

        public ICommand AddModelButton { get; }
        public ICommand DeleteModelButton { get; }

        public ICommand CreateOrderAndPrintButton { get; }
        public ICommand SaveButton { get; }
        public ICommand CancleButton { get; }

        public CreatingOrderViewModel(OrdersListingViewModel ordersListingViewModel, IOrderService orderService, IDeviceStateService deviceStateService)
        {
            _orderService = orderService;
            _deviceStateService = deviceStateService;
            AddDeviceButton = new AddDeviceCommand(this, deviceStateService);
            AddModelButton = new AddModelCommand(this, deviceStateService);

            SaveButton = new SaveOrderCommand(this, orderService, ordersListingViewModel);
        }

        public void Clear()
        {
            ContactNameTextBox = string.Empty;
            ContactPhoneNumberTextBox = string.Empty;
            DeviceNameComboBox = string.Empty;
            ModelNameComboBox = string.Empty;
            DescriptionTextBox = string.Empty;
            ToDoTextBox = string.Empty;
            AccessoriesTexBox = string.Empty;
            OrderNameTextBlock = SetOrderName();
        }

        private string SetOrderName()
        {
            OrderNo = _orderService.GetOrderNumber().Result;

            return "Z/" + OrderNo + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");
        }

        private string PhoneValisation(string phoneNumber)
        {
            if (phoneNumber.Length > 11)
            {
                return phoneNumber.Substring(0, 11);
            }

            var isNotNumber = new Regex("[^0-9 ]").IsMatch(phoneNumber);
            if (isNotNumber)
            {
                var result = phoneNumber.Substring(0, phoneNumber.Length - 1);
                return result;
            }

            return Regex.Replace(phoneNumber, "(\\d{3})(?=\\d)", "$1 "); ;
        }
    }
}