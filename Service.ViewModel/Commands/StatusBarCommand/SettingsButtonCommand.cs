using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.StatusBarViewVModels;

namespace Service.ViewModel.Commands.StatusBarCommand
{
    internal class SettingsButtonCommand : CommandBase
    {
        private readonly IDialogService _dialogService;
        private readonly SettingsViewModel _settingsViewModel;

        public SettingsButtonCommand(IDialogService dialogService, SettingsViewModel settingsViewModel)
        {
            _dialogService = dialogService;
            _settingsViewModel = settingsViewModel;
        }

        public override void Execute(object? parameter)
        {
            _dialogService.ShowDialog(_settingsViewModel);
        }
    }
}