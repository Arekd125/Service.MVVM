﻿using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using Servis.Models.OrderModels;
using System.ComponentModel;

namespace Service.ViewModel.Commands
{
    public class SaveOrderCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;
        private readonly ContactViewModel _contactViewModel;

        public SaveOrderCommand(CreatingOrderViewModel creatingOrderViewModel, ContactViewModel contactViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _contactViewModel = contactViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _contactViewModel.PropertyChanged += OnViewModelPropertyChanged;

        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_contactViewModel.ContactPhoneNumberTextBox) &&
                    _contactViewModel.ContactPhoneNumberTextBox.Length > 10 &&
                   !string.IsNullOrEmpty(_creatingOrderViewModel.DeviceNameComboBox) &&
                   !string.IsNullOrEmpty(_creatingOrderViewModel.ModelNameComboBox));
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.SaveOrder();
        }
    }
}