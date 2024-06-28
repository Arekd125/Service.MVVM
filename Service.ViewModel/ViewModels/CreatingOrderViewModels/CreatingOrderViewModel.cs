﻿using AutoMapper;
using MediatR;
using Service.ViewModel.Commands.CreatingOrderCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Commands.CreateOrder;
using Service.ViewModel.Service.Commands.EditOrder;
using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels.PrintOrderViewModels;
using System.Windows;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class CreatingOrderViewModel : ViewModelBase

    {
        private readonly OrderStore _orderStore;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IShowDialog showDialog;

        private Visibility _saveButtonVisibility = Visibility.Visible;

        public Visibility SaveButtonVisibility
        {
            get
            {
                return _saveButtonVisibility;
            }
            set
            {
                _saveButtonVisibility = value;
                OnPropertyChanged(nameof(SaveButtonVisibility));
            }
        }

        private Visibility _editButtonVisibility = Visibility.Hidden;

        public Visibility EditButtonVisibility
        {
            get
            {
                return _editButtonVisibility;
            }
            set
            {
                _editButtonVisibility = value;
                OnPropertyChanged(nameof(EditButtonVisibility));
            }
        }

        public FlyoutVewModel FlyoutVewModel { get; }
        public NameOrderViewModel NameOrderViewModel { get; }
        public ContactViewModel ContactViewModel { get; }
        public DeviceViewModel DeviceViewModel { get; }
        public DescriptionViewModel DescriptionViewModel { get; }

        public ICommand PrintButton { get; }
        public ICommand SaveButton { get; }
        public ICommand EditButton { get; }
        public ICommand CancleButton { get; }

        public CreatingOrderViewModel(
            FlyoutVewModel flayoutVewModel,
            NameOrderViewModel nameOrderViewModel,
            ContactViewModel contactViewModel,
            DeviceViewModel deviceViewModel,
            DescriptionViewModel descriptionViewModel,
            OrderStore orderStore,
            PrintOrderViewModel printOrderViewModel,
            IMediator mediator,
            IMapper mapper,
            IDialogService dialogService
            )
        {
            _orderStore = orderStore;
            _mediator = mediator;
            FlyoutVewModel = flayoutVewModel;
            NameOrderViewModel = nameOrderViewModel;
            ContactViewModel = contactViewModel;
            DeviceViewModel = deviceViewModel;
            DescriptionViewModel = descriptionViewModel;

            SaveButton = new SaveOrderButtonCommand(this, ContactViewModel, DeviceViewModel, descriptionViewModel);
            EditButton = new SaveEditedOrderButtonCommand(this, ContactViewModel, DeviceViewModel, descriptionViewModel);
            CancleButton = new CancleButtonCommand(this);
            PrintButton = new PrintButtonCommand(this, ContactViewModel, DeviceViewModel, dialogService, printOrderViewModel, descriptionViewModel);

            _orderStore.OrderSentToEdit += OnOrderEdited;
            _mapper = mapper;
        }

        private int OrderId { get; set; }

        private void OnOrderEdited(OrderDto EditOrder)
        {
            Clear();
            SaveButtonVisibility = Visibility.Collapsed;
            EditButtonVisibility = Visibility.Visible;
            OrderId = EditOrder.Id;
            NameOrderViewModel.OrderNameTextBlock = EditOrder.OrderName;
            ContactViewModel.ContactNameComboBox = EditOrder.ContactName;
            ContactViewModel.ContactPhoneNumberComboBox = EditOrder.ContactPhoneNumber;
            DeviceViewModel.DeviceNameComboBox = EditOrder.Device;
            DeviceViewModel.ModelNameComboBox = EditOrder.Model;
            DescriptionViewModel.SetToDoItems(EditOrder.ToDo);
            DescriptionViewModel.DescriptionTextBox = EditOrder.Description;
            DescriptionViewModel.AccessoriesTexBox = EditOrder.Accessories;
        }

        public void EditOrder()
        {
            OrderDto orderDto = CreateOrderDto();

            EditOrderCommand command = _mapper.Map<EditOrderCommand>(orderDto);

            _mediator.Send(command);

            FlyoutVewModel.ShowFlyout($"Edytowano zlecenie \n{orderDto.OrderName}");

            AddDeviceIfNotExist();
            _orderStore.OrderChanged(orderDto);
            Clear();
        }

        public void SaveOrder()
        {
            OrderDto orderDto = CreateOrderDto();

            CreateOrderCommand command = _mapper.Map<CreateOrderCommand>(orderDto);

            _mediator.Send(command);

            FlyoutVewModel.ShowFlyout($"Dodano zlecenie \n{orderDto.OrderName}");

            AddDeviceIfNotExist();
            _orderStore.AddLastOrder(orderDto);
            Clear();
        }

        public void Clear()
        {
            EditButtonVisibility = Visibility.Collapsed;
            SaveButtonVisibility = Visibility.Visible;
            DeviceViewModel.Clear();
            DescriptionViewModel.Clear();
            ContactViewModel.Clear();
            NameOrderViewModel.SetNextOrderName();
        }

        public OrderDto CreateOrderDto()
        {
            NameOrderViewModel.SetNextOrderName();
            return new OrderDto
            {
                Id = OrderId,
                OrderNo = NameOrderViewModel.OrderNo,
                OrderName = NameOrderViewModel.OrderNameTextBlock,
                StartDate = DateTime.Now.ToString("d"),
                ContactName = ContactViewModel.ContactNameComboBox,
                ContactPhoneNumber = ContactViewModel.ContactPhoneNumberComboBox,
                Device = DeviceViewModel.DeviceNameComboBox,
                Model = DeviceViewModel.ModelNameComboBox,
                ToDo = DescriptionViewModel.ToDoSelectedItems.ToList(),
                Cost = SumCost(DescriptionViewModel.ToDoSelectedItems.ToList()),
                Description = DescriptionViewModel.DescriptionTextBox,
                Accessories = DescriptionViewModel.AccessoriesTexBox
            };
        }

        private decimal SumCost(IEnumerable<ToDoDto> toDoItems)
        {
            return toDoItems.Sum(item => item.Price);
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