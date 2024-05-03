using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class NameOrderViewModel
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;
        private readonly IOrderService _orderService;


        public int OrderNo => SetOrderNo();
        public string OrderNameTextBlock => SetOrderName(OrderNo);




        public NameOrderViewModel(CreatingOrderViewModel creatingOrderViewModel, IOrderService orderService)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _orderService = orderService;
        }

        public string SetOrderName(int orderNo)
        {
            return "Z/" + orderNo + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");
        }
        public int SetOrderNo()
        {
            return  _orderService.GetOrderNumber().Result;
        }
        

    }
}
