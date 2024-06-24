using Service.View.Views.PrintOrderViews;
using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.PrintOrderViewModels;

namespace Service.View.Dialogs
{
    public class PrintDialogService : IPrintDialogService
    {
        public void ShowDialog(PrintOrderViewModel printOrderViewModel)
        {
            var dialog = new PrintOrderView();
            dialog.DataContext = printOrderViewModel;

            dialog.ShowDialog();
        }
    }
}