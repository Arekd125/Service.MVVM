using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class OrdersListingViewModel : ViewModelBase
    {
        private ObservableCollection<OrdersViewModel> _ordersViewModelColection;
        public IEnumerable<OrdersViewModel> ordersViewModelColection => _ordersViewModelColection;

        public OrdersListingViewModel()
        {
            _ordersViewModelColection = new ObservableCollection<OrdersViewModel>();
        }

        public void Add(Order order)
        {
            OrdersViewModel OrdersViewModel = new OrdersViewModel(order);

            _ordersViewModelColection.Add(OrdersViewModel);
        }
    }
}