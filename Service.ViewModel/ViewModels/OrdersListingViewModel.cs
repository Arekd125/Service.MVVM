using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel : ViewModelBase
    {
        private ObservableCollection<OrdersViewModel> _ordersViewModelColection;
        private readonly List<Order> _orders;

        public IEnumerable<OrdersViewModel> ordersViewModel => _ordersViewModelColection;

        public OrdersListingViewModel(List<Order> orders)
        {
            _ordersViewModelColection = new ObservableCollection<OrdersViewModel>();

            _orders = orders;
        }
    }
}