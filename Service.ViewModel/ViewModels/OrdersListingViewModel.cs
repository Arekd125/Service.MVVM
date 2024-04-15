using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel
    {
        private ObservableCollection<OrdersViewModel> _ordersViewModelColection;

        public IEnumerable<OrdersViewModel> ordersViewModel => _ordersViewModelColection;

        public OrdersListingViewModel()
        {
        }
    }
}