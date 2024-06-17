using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.View.Views.PrintOrderViews
{
    public class DialogService : IDialogService
    {
        public void ShowDialog()
        {
            var dialog = new PrintOrderView();
            dialog.ShowDialog();
        }
    }
}