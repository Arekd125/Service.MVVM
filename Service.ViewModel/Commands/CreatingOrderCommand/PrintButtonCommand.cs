using Service.ViewModel.Service;
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

        public PrintButtonCommand(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public override void Execute(object? parameter)
        {
            _dialogService.ShowDialog();
        }
    }
}