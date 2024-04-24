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
        private ObservableCollection<DisplayOrderDto> _ordersViewModelColection;
        private readonly IOrderService _orderService;

        public IEnumerable<DisplayOrderDto> ordersViewModelColection => _ordersViewModelColection;

        public OrdersListingViewModel(IOrderService orderService)
        {
            _ordersViewModelColection = new ObservableCollection<DisplayOrderDto>();
            _orderService = orderService;
        }

        public void AddLast()
        {
            var displayOrderDto = _orderService.GetLastOrder().Result;

            Add(displayOrderDto);
        }

        private void Add(DisplayOrderDto displayOrderDto)
        {
            _ordersViewModelColection.Insert(0, displayOrderDto);
        }

        public void Add(IEnumerable<DisplayOrderDto> displayOrdersDto)
        {
            foreach (var o in displayOrdersDto)
            {
                Add(o);
            }
        }
    }
}