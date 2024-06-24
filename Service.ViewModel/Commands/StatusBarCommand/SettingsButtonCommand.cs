using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.StatusBarViewVModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.StatusBarCommand
{
    internal class SettingsButtonCommand : CommandBase
    {
        private readonly IDialogService _dialogService;

        public SettingsButtonCommand(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public override void Execute(object? parameter)
        {
            _dialogService.ShowDialog<SettingsViewModel>();
        }
    }
}