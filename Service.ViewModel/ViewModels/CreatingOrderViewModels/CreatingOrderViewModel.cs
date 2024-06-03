using AutoMapper;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using MediatR;
using Service.Model.Entity;
using Service.ViewModel.Commands;
using Service.ViewModel.Commands.CreatingOrderCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Commands.CreateOrder;
using Service.ViewModel.Service.Queries.GetOrder;
using Service.ViewModel.Stores;
using Servis.Models.OrderModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class CreatingOrderViewModel : ViewModelBase

    {
        private readonly OrderStore _orderStore;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

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
            IMediator mediator,
            IMapper mapper
            )
        {
            _orderStore = orderStore;
            _mediator = mediator;
            FlyoutVewModel = flayoutVewModel;
            NameOrderViewModel = nameOrderViewModel;
            ContactViewModel = contactViewModel;
            DeviceViewModel = deviceViewModel;
            DescriptionViewModel = descriptionViewModel;

            SaveButton = new SaveOrderButtonCommand(this, ContactViewModel, DeviceViewModel);
            CancleButton = new CancleButtonCommand(this);
            _orderStore.OrderEdited += OnOrderEdited;
            _mapper = mapper;
        }

        private void OnOrderEdited(OrderDto EditOrder)
        {
           // var EditOrder = _mediator.Send(new GetOrderQuery(OrderName)).Result;

            NameOrderViewModel.OrderNameTextBlock = EditOrder.OrderName;
            ContactViewModel.ContactNameComboBox = EditOrder.ContactName;
            ContactViewModel.ContactPhoneNumberComboBox = EditOrder.ContactPhoneNumber;
            DeviceViewModel.DeviceNameComboBox = EditOrder.Device;
            DeviceViewModel.ModelNameComboBox = EditOrder.Model;
            DescriptionViewModel.AddItemsToDoSelectedItems(EditOrder.ToDo);

            DescriptionViewModel.DescriptionTextBox = EditOrder.Description;
            DescriptionViewModel.AccessoriesTexBox = EditOrder.Accessories;
        }

        public void Clear()
        {
            DeviceViewModel.DeviceNameComboBox = string.Empty;
            DeviceViewModel.ModelNameComboBox = string.Empty;
            DescriptionViewModel.DescriptionTextBox = string.Empty;
            DescriptionViewModel.ToDoSelectedItems.Clear();
            DescriptionViewModel.AccessoriesTexBox = string.Empty;
            ContactViewModel.RefreshContactsItemSorce();
            ContactViewModel.ContactNameComboBox = string.Empty;
            ContactViewModel.ContactPhoneNumberComboBox = string.Empty;
            NameOrderViewModel.SetNextOrderName();
        }

        public void SaveOrder()
        {

            OrderDto orderDto = new()
            {
                OrderNo = NameOrderViewModel.OrderNo,
                OrderName = NameOrderViewModel.OrderNameTextBlock,
                ContactName = ContactViewModel.ContactNameComboBox,
                ContactPhoneNumber = ContactViewModel.ContactPhoneNumberComboBox,
                Device = DeviceViewModel.DeviceNameComboBox,
                Model = DeviceViewModel.ModelNameComboBox,
                ToDo = DescriptionViewModel.ToDoSelectedItems.ToList(),
                Cost = SumCost(DescriptionViewModel.ToDoSelectedItems.ToList()),
                Description = DescriptionViewModel.DescriptionTextBox,
                Accessories = DescriptionViewModel.AccessoriesTexBox
            };

            
            CreateOrderCommand command = _mapper.Map<CreateOrderCommand>(orderDto);

            _mediator.Send(command);

            FlyoutVewModel.ShowFlyout("Dodano zlecenie");
            AddDeviceIfNotExist();
            _orderStore.AddLastOrder(orderDto);
            Clear();
        }

        private decimal SumCost(List<ToDoDto> toDo)
        {
            decimal sum = 0;
            foreach (ToDoDto dto in toDo)
            {
                sum += dto.Prize;
            }
            return sum;
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