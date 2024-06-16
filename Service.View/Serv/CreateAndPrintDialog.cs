using Service.View.Views;
using Service.View.Views.CreatingOrderViews;
using Service.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.View.Serv
{
    internal class CreateAndPrintDialog : IShowDialog
    {
        public void ShowDialog()
        {
            var dialog = new CreateAndPrintView();

            dialog.ShowDialog();
        }
    }


}
