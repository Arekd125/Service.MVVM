using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public interface IFilter
    {
        IEnumerable<OrderDto> GetOrderDtos();
    }
}