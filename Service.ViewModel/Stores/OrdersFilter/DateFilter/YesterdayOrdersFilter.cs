using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetOrderByDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.OrderFiltr.DateFilter
{
    public class YesterdayOrdersFilter : IFilter
    {
        private readonly IMediator _mediator;

        public YesterdayOrdersFilter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<OrderDto> GetOrderDtos()
        {
            return _mediator.Send(new GetOrderByDateQuery(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1))).Result;
        }
    }
}