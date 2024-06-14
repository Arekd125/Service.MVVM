using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetOrderByDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public class LastWeekOrdersFilter : IFilter
    {
        private readonly IMediator _mediator;

        public LastWeekOrdersFilter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<OrderDto> GetOrderDtos()
        {
            return _mediator.Send(new GetOrderByDateQuery(DateTime.Now, DateTime.Now.AddDays(-7))).Result;
        }
    }
}