using Service.ViewModel.ViewModels.PrintOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public interface IDialogService
    {
        public void ShowDialog(PrintOrderViewModel printOrderView);
    }
}