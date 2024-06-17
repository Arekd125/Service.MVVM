using Service.ViewModel.ViewModels;

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