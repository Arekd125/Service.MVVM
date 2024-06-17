using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.PrintOrderViewModels
{
    public class PrintOrderViewModel
    {
        public PrintOrderViewModel(PrintViewModel printViewModel)
        {
            PrintViewModel = printViewModel;
        }

        public PrintViewModel PrintViewModel { get; }
    }
}