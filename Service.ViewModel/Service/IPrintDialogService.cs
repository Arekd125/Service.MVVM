using Service.ViewModel.ViewModels.PrintOrderViewModels;

namespace Service.ViewModel.Service
{
    public interface IPrintDialogService
    {
        public void ShowDialog(PrintOrderViewModel printOrderView);
    }
}