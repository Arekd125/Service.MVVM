using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public abstract class FiltrDecorator : IFilter
    {
        private IFilter _filter;

        protected FiltrDecorator(IFilter filter)
        {
            _filter = filter;
        }

        public virtual IEnumerable<OrderDto> GetOrderDtos()
        {
            return _filter.GetOrderDtos();
        }
    }
}