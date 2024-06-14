using Service.ViewModel.Stores;
using Service.ViewModel.Stores.Converstes;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.PanelControlCommand
{
    public class ToggleSwitchOnCommand : CommandBase
    {
        private readonly PanelControlViewModel _panelControlViewModel;
        private readonly OrderStore _orderStore;

        public ToggleSwitchOnCommand(PanelControlViewModel panelControlViewModel, OrderStore orderStore)
        {
            _panelControlViewModel = panelControlViewModel;
            _orderStore = orderStore;
        }

        public override void Execute(object? parameter)
        {
            _panelControlViewModel.BufforDateFilerSelectedIndex = _panelControlViewModel.DateFilerSelectedIndex;
            _panelControlViewModel.DateFilerSelectedIndex = (int)DateFilerEnum.from_the_beginning;
            _orderStore.SetFiltrAllOrders();
        }
    }
}