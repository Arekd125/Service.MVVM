using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.PrintOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class PrintButtonCommand : CommandBase
    {
        private readonly IDialogService _dialogService;
        private readonly PrintOrderViewModel _printOrderViewModel;

        public PrintButtonCommand(IDialogService dialogService, PrintOrderViewModel printOrderViewModel)
        {
            _dialogService = dialogService;
            _printOrderViewModel = printOrderViewModel;
        }

        public override void Execute(object? parameter)
        {
            _dialogService.ShowDialog(_printOrderViewModel);
        }
    }
}