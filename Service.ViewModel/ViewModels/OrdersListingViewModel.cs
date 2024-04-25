using Microsoft.VisualBasic;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
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
        private ObservableCollection<DisplayOrderDto> _ordersViewModelCollection;
        private readonly IOrderService _orderService;

        public IEnumerable<DisplayOrderDto> ordersViewModelCollection => _ordersViewModelCollection;

        public OrdersListingViewModel(IOrderService orderService)
        {
            _ordersViewModelCollection = new ObservableCollection<DisplayOrderDto>();
            _orderService = orderService;

            AllOrders();
        }

        public void AddLast()
        {
            var displayOrderDto = _orderService.GetLastOrder().Result;

            Add(displayOrderDto);
        }

        private void Add(DisplayOrderDto displayOrderDto)
        {
            _ordersViewModelCollection.Insert(0, displayOrderDto);
        }

        private void AllOrders()
        {
            var getAllOrders = _orderService.GetAllOrders().Result;

            foreach (var o in getAllOrders)
            {
                Add(o);
            }
        }
    }
}