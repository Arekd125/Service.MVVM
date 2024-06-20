using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class StatusBarViewModel : ViewModelBase
    {
        private int _openedOrders;

        public int OpenedOrders
        {
            get
            {
                return _openedOrders;
            }
            set
            {
                _openedOrders = value;
                OnPropertyChanged(nameof(OpenedOrders));
            }
        }
    }
}