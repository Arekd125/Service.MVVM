using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using Service.ViewModel.Commands;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class CreatingOrderViewModel : ViewModelBase

    {
        private readonly IOrderService _orderService;
        private readonly IDeviceStateService _deviceStateService;
        private readonly NameOrderViewModel _nameOrderViewModel;
        private readonly ContactViewModel _contactViewModel;
        private IDialogCoordinator dialogCoordinator;
        private readonly OrdersListingViewModel _ordersListingViewModel;






        
        public int OrderNo => _nameOrderViewModel.SetOrderNo();
        public string OrderNameTextBlock => _nameOrderViewModel.SetOrderName(OrderNo);

        private string _contactName = string.Empty;

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

        private string _contactPhoneNumber = string.Empty;

        public string ContactPhoneNumberTextBox
        {
            get
            {
                return _contactPhoneNumber;
            }
            set
            {
                _contactPhoneNumber = _contactViewModel.PhoneValisation(value);

                OnPropertyChanged(nameof(ContactPhoneNumberTextBox));
            }
        }

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

        private string _deviceStateSelectedItem = string.Empty;

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

        private string _modelStateSelectedItem = string.Empty;

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

        private string _deviceName = string.Empty;

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

        private string _ModelName = string.Empty;

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

        private bool _openFlyout = false;
        public bool OpenFlyout
        { 
            get
            {
               
                return _openFlyout;
            } 
            set 
            {

                _openFlyout = value;
                OnPropertyChanged(nameof(OpenFlyout));

            } 
        }
        private string _messageFlyout;
        public string MessageFlyout
        {
            get
            {
                
                return _messageFlyout;
            }
            set
            {

                _messageFlyout = value;
                OnPropertyChanged(nameof(MessageFlyout));

            }
        }
       




        public ICommand AddDeviceButton { get; }
        public ICommand DeleteDeviceButton { get; }

        public ICommand AddModelButton { get; }
        public ICommand DeleteModelButton { get; }

        public ICommand CreateOrderAndPrintButton { get; }
        public ICommand SaveButton { get; }
        public ICommand CancleButton { get; }

        public CreatingOrderViewModel(IDialogCoordinator instance
                , OrdersListingViewModel ordersListingViewModel
                , IOrderService orderService
                , IDeviceStateService deviceStateService)
        {
            _orderService = orderService;
            _deviceStateService = deviceStateService;
            dialogCoordinator = instance;
            _ordersListingViewModel = ordersListingViewModel;

            _nameOrderViewModel = new NameOrderViewModel(this, orderService);
            _contactViewModel = new ContactViewModel(this, orderService);

            AddDeviceButton = new AddDeviceCommand(this, deviceStateService);
            DeleteDeviceButton = new DeleteDeviceCommand(this);
            AddModelButton = new AddModelCommand(this);
            DeleteModelButton = new DeleteModelCommand(this);
            SaveButton = new SaveOrderCommand(this);
            CancleButton = new CancleCommand(this);
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
            OnPropertyChanged(nameof(OrderNameTextBlock));

            

        }

        public async void ShowMessage()
        {
            var themes = ThemeManager.Current.DetectTheme().Resources;
            themes["Theme.ThemeInstance"] = ThemeManager.Current.GetTheme("Light.Red");

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Tak",
                NegativeButtonText = "Anuluj",
                AnimateShow = false,
                CustomResourceDictionary = themes,
                ColorScheme = MetroDialogColorScheme.Accented
            };

            var title = $"Usunąć markę {DeviceStateSelectedItem}?";
            var models = string.Join(", ", ModelStateNameItemSorce);
            var message = $"Zostaną również usunięte następujące modele: {models}";

            

            MessageDialogResult result = await dialogCoordinator.ShowMessageAsync(
                                            this,
                                            title,
                                            message,
                                            MessageDialogStyle.AffirmativeAndNegative,
                                            mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                DeleteDeviceAndModels();
            }
        }

        public  void  DeleteModel()
        {
            _deviceStateService.DeleteModel(DeviceStateSelectedItem,ModelStateSelectedItem);
            var message = $"Usunięto Modelu {ModelStateSelectedItem}";
            ShowFlyout(message);

            ModelStateSelectedItem = null;
           ModelStateNameItemSorce = _deviceStateService.GetAllModelName(DeviceStateSelectedItem).Result;
        }
        public void DeleteDeviceAndModels()
        {
            _deviceStateService.DeleteDevice(DeviceStateSelectedItem);
            var message = $"Usunięto Markę {DeviceStateSelectedItem}";
            ShowFlyout(message);
            DeviceStateSelectedItem = null;
            DeviceStateNameItemsSource = _deviceStateService.GetAllDeviceName().Result;
            
            
        }

        public IEnumerable<string> AllModelStateName()
        {
            return _deviceStateService.GetAllModelName(DeviceStateSelectedItem).Result;
        }

        public async void SaveDeviceState()

        {
            DeviceState deviceState = new()
            {
                Name = DeviceNameComboBox
            };
            await _deviceStateService.CreateDevice(deviceState);
            DeviceStateNameItemsSource = await _deviceStateService.GetAllDeviceName();
            DeviceStateSelectedItem = DeviceNameComboBox;

            var message = $"Dodano Markę {DeviceNameComboBox}";
            ShowFlyout(message);
            
        }

        public async void SaveModelState()
        {
            ModelState modelState = new()
            {
                Name = ModelNameComboBox
            };

            var deviceStateName = DeviceStateSelectedItem;
            await _deviceStateService.AddModel(modelState, deviceStateName);
            ModelStateNameItemSorce = AllModelStateName();
            ModelStateSelectedItem = ModelNameComboBox;

            var message = $"Dodano Model {ModelNameComboBox}";
            ShowFlyout(message);
        }

        public void SaveOrder()
        {
            CreateOrderDto orderdto = new()
            {
                OrderNo = OrderNo,
                OrderName = OrderNameTextBlock,
                ContactName = ContactNameTextBox,
                ContactPhoneNumber = ContactPhoneNumberTextBox,
                Device = DeviceNameComboBox,
                Model = ModelNameComboBox,
                Description = DescriptionTextBox,
                ToDo = ToDoTextBox,
                Accessories = AccessoriesTexBox
            };

            _orderService.CreateOrder(orderdto);
            ShowFlyout("Dodano Zlecenie");
            AddDeviceIfNotExist();
            _ordersListingViewModel.AddLast();
            Clear();
        }

        private void AddDeviceIfNotExist()
        {
            if (DeviceStateSelectedItem == null)
            {
                SaveDeviceState();
                
            }

            if (ModelStateSelectedItem == null)
            {
                SaveModelState();
            }
        }

       
        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public async Task ShowFlyout(string flyoutmessage)
        {
            await semaphore.WaitAsync(); 
            try
            {
                OpenFlyout = true; 
                MessageFlyout = flyoutmessage; 

                await Task.Delay(3000);

                OpenFlyout = false;
            }
            finally
            {
                semaphore.Release(); 
            }
        }


    }
}