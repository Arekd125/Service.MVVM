using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetAllOrders;

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
