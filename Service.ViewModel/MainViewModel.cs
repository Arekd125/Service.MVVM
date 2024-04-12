using Service.ViewModel.Commands;
using Servis.Models.OrderBuilder;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.ViewModel;

public class MainViewModel : ViewModelBase

{
    private ObservableCollection<OrdersViewModel> _orders;

    public IEnumerable<OrdersViewModel> Orders => _orders;

    public MainViewModel()
    {
        _orders = new ObservableCollection<OrdersViewModel>();

        SaveButton = new SaveOrderCommand();

        //OrderBuilder orderBuilder = new OrderBuilder();
        //ContactBuilder contactBuilder = new ContactBuilder("ContactNameTextBox", "ContactPhoneNumberTextBox");
        //ModelBuilder modelBuilder = new ModelBuilder("DeviceModelNameComboBox.Text");
        //DeviceBuilder deviceBuilder = new DeviceBuilder("DeviceNameComboBox.Text", modelBuilder.Build());

        //orderBuilder.SetContact(contactBuilder.Build());
        //orderBuilder.SetDevice(deviceBuilder.Build());
        //orderBuilder.SetOrderNo(321);
        //orderBuilder.SetStartDate(DateTime.Now);

        //var ordersbild = orderBuilder.Build();
        //var ordersViewModel = new OrdersViewModel(ordersbild);
        //_orders.Add(ordersViewModel);
        //_orders.Add(ordersViewModel);
        //_orders.Add(ordersViewModel);
    }

    private int _orderNo;

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

    private DateTime _StartDate;

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
}