using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.PrintOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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