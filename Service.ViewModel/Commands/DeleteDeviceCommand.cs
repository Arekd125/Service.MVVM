﻿using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Service.ViewModel.Commands
{
    public class DeleteDeviceCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public DeleteDeviceCommand(CreatingOrderViewModel creatingOrderViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.DeviceStateSelectedItem));
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_creatingOrderViewModel.ModelStateNameItemSorce.Count() != 0)
            {
                _creatingOrderViewModel.ShowMessage();
            }
            else
            {
                _creatingOrderViewModel.DeleteDeviceAndModels();
            }
        }
    }
}