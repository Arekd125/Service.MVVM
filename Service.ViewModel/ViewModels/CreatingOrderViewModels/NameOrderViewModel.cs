using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class NameOrderViewModel : ViewModelBase
    {
        private readonly IOrderService _orderService;


        public int OrderNo => SetOrderNo();
       


        private string _orderNameTextBlock;

        public string OrderNameTextBlock
        {
            get
            {
                 
                return _orderNameTextBlock;
            }
            set
            {

                _orderNameTextBlock = value;
              
                OnPropertyChanged(nameof(OrderNameTextBlock));
            }
        }



        public NameOrderViewModel(IOrderService orderService)
        {
            _orderService = orderService;
           SetNextOrderName();
        }
        
      
        private string SetOrderName(int orderNo)
        {

            return "Z/" + orderNo + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");
        }
        private int SetOrderNo()
        {
            return  _orderService.GetOrderNumber().Result;
        }
        public void SetNextOrderName()
        {
            OrderNameTextBlock = SetOrderName(OrderNo);

        }
    }
}
