using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.PrintOrderViewModels;

namespace Service.View.Views.PrintOrderViews
{
    public class DialogService : IDialogService
    {
        public void ShowDialog(PrintOrderViewModel printOrderViewModel)
        {
            var dialog = new PrintOrderView();
            dialog.DataContext = printOrderViewModel;

            dialog.ShowDialog();
        }
    }
}