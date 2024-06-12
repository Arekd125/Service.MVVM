using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class OrderStatusTabControlViewModel : ViewModelBase
    {
        private int _filtrStatus;

        public int FiltrStatus
        {
            get
            {
                return _filtrStatus;
            }
            set
            {
                _filtrStatus = value;
                OnPropertyChanged(nameof(FiltrStatus));
                ordersListingViewModel.SlelectFiltr(FiltrStatus);
            }
        }

        public OrdersListingViewModel ordersListingViewModel { get; }

        public OrderStatusTabControlViewModel(OrdersListingViewModel ordersListingViewModel)
        {
            this.ordersListingViewModel = ordersListingViewModel;
        }
    }
}