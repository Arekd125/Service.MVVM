using Service.ViewModel.ViewModels.CreatingOrderViewModels;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class CancleButtonCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public CancleButtonCommand(CreatingOrderViewModel creatingOrderViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.Clear();
        }
    }
}