using Service.ViewModel.ViewModels.PrintOrderViewModels;

namespace Service.ViewModel.Service
{
    public interface IDialogService
    {
        public void ShowDialog(PrintOrderViewModel printOrderView);
    }
}