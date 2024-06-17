using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetOrderByDate;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public class TodayOrdersFiilter : IFilter
    {
        private readonly IMediator _mediator;

        public TodayOrdersFiilter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<OrderDto> GetOrderDtos()
        {
            return _mediator.Send(new GetOrderByDateQuery(DateTime.Now, DateTime.Now)).Result;
        }
    }
}