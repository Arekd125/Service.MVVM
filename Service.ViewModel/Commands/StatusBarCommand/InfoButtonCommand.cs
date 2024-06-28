﻿using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.StatusBarViewVModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.StatusBarCommand
{
    public class InfoButtonCommand : CommandBase
    {
        private readonly IDialogService _dialogService;
        private readonly InfoViewModel _infoViewModel;

        public InfoButtonCommand(IDialogService dialogService, InfoViewModel infoViewModel)
        {
            _dialogService = dialogService;
            _infoViewModel = infoViewModel;
        }

        public override void Execute(object? parameter)
        {
            _dialogService.ShowDialog(_infoViewModel);
        }
    }
}