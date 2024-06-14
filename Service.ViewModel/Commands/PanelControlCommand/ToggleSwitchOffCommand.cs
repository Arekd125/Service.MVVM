using Service.ViewModel.Stores.Converstes;
using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.PanelControlCommand
{
    public class ToggleSwitchOffCommand : CommandBase
    {
        private readonly PanelControlViewModel _panelControlViewModel;

        public ToggleSwitchOffCommand(PanelControlViewModel panelControlViewModel)
        {
            _panelControlViewModel = panelControlViewModel;
        }

        public override void Execute(object? parameter)
        {
            _panelControlViewModel.DateFilerSelectedIndex = _panelControlViewModel.BufforDateFilerSelectedIndex;
        }
    }
}