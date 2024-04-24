using Microsoft.Extensions.DependencyInjection;
using Service.Model.Services;
using Service.Model.Services.ServicesDevice;
using Service.ViewModel.Commands;
using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels
{
    public class CreatingOrderViewModel : ViewModelBase
    {
        private readonly ServiceDeviceState _serviceDeviceState;

        private IEnumerable<string> _deviceStateNameComboBox;

        public IEnumerable<string> DeviceStateNameComboBox
        {
            get
            {
                _deviceStateNameComboBox = _serviceDeviceState.GetAllDeviceName();
                return _deviceStateNameComboBox;
            }
            set
            {
                _deviceStateNameComboBox = value;
                OnPropertyChanged(nameof(DeviceStateNameComboBox));
            }
        }

        private IEnumerable<string> _modelStateNameComboBox;

        public IEnumerable<string> ModelStateNameComboBox
        {
            get
            {
                return _modelStateNameComboBox;
            }
            set
            {
                _modelStateNameComboBox = value;
                OnPropertyChanged(nameof(ModelStateNameComboBox));
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
                ModelStateNameComboBox = _serviceDeviceState.GetAllModelName(DeviceStateSelectedItem);
            }
        }

        private int _orderNo = 1;

        public int OrderNoNumericUpDown
        {
            get
            {
                return _orderNo;
            }
            set
            {
                _orderNo = value;
                OnPropertyChanged(nameof(OrderNoNumericUpDown));
            }
        }

        private DateTime _StartDate = DateTime.Now;

        public DateTime StartDateDatePicker
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
                OnPropertyChanged(nameof(StartDateDatePicker));
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
                _contactPhoneNumber = value;
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

        private string _deviceModelName;

        public string DeviceModelNameComboBox
        {
            get
            {
                return _deviceModelName;
            }
            set
            {
                _deviceModelName = value;
                OnPropertyChanged(nameof(DeviceModelNameComboBox));
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

        public ICommand CreateOrderAndPrintButton { get; }

        public ICommand SaveButton { get; }
        public ICommand CancleButton { get; }
        public ICommand AddDeviceButton { get; }
        public ICommand RemoveDeviceButton { get; }
        public ICommand DeleteDeviceButton { get; }
        public ICommand EditDeviceButton { get; }

        public CreatingOrderViewModel(IOrderService orderCreator, OrdersListingViewModel ordersListingViewModel, IDeviceProvider deviceProvider, IDeviceCreator deviceCreator)
        {
            SaveButton = new SaveOrderCommand(this, orderCreator, ordersListingViewModel);
            _serviceDeviceState = new ServiceDeviceState(deviceProvider, deviceCreator);
            AddDeviceButton = new AddDeviceCommand(this, _serviceDeviceState);
        }

        public void Clear()
        {
            ContactNameTextBox = string.Empty;
            ContactPhoneNumberTextBox = string.Empty;
            DeviceNameComboBox = string.Empty;
            DeviceModelNameComboBox = string.Empty;
            DescriptionTextBox = string.Empty;
            ToDoTextBox = string.Empty;
            AccessoriesTexBox = string.Empty;
        }
    }
}