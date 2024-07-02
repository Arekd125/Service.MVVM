using Service.ViewModel.ViewModels.PrintOrderViewModels;
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