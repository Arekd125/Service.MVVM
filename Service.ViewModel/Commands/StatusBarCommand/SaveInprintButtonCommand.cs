using Service.ViewModel.ViewModels.PrintOrderViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.ViewModel.Extensions.ServiceCollectionExtension;

namespace Service.ViewModel.Commands.StatusBarCommand
{
    public class SaveInprintButtonCommand : CommandBase
    {
        private readonly Inprint _inprint;

        public SaveInprintButtonCommand(Inprint inprint)
        {
            _inprint = inprint;
        }

        public override void Execute(object? parameter)
        {
            AppSettingsHelper.UpdateInprintSettings(_inprint);
        }
    }
}