using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetAllOrders;
using Service.ViewModel.Service.Queries.GetOrderByDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.OrderFiltr.DateFilter
{
    public class FromTheBeginingOrdersFilter : IFilter
    {
        private readonly IMediator _mediator;

        public FromTheBeginingOrdersFilter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<OrderDto> GetOrderDtos()
        {
            return _mediator.Send(new GetAllOrdersQuery()).Result;
        }
    }
}
