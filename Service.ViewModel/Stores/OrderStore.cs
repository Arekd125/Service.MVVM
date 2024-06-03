using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores
{
    public class OrderStore
    {
        public event Action<OrderDto> OrderCreated;

        public event Action<OrderDto> OrderEdited;

        public void AddLastOrder(OrderDto orderDto)
        {
            OrderCreated?.Invoke(orderDto);
        }

        public void EditOrder(OrderDto orderName)
        {
            OrderEdited?.Invoke(orderName);
        }
    }
}