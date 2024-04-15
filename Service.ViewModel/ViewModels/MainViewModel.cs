using Service.ViewModel.Commands;
using Servis.Models.OrderBuilder;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
    public OrdersListingViewModel ordersListingViewModel { get; set; }
    public CreatingOrderViewModel creatingOrderViewModel { get; set; }

    public MainViewModel(List<Order> _orders)
    {
        ordersListingViewModel = new OrdersListingViewModel();
        creatingOrderViewModel = new CreatingOrderViewModel(_orders);
    }
}