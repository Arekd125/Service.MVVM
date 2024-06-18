using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetOrderByDate;

namespace Service.ViewModel.Stores.OrderFiltr.DateFilter
{
    public class LastMonth : IFilter
    {
        private readonly IMediator _mediator;

        public LastMonth(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEnumerable<OrderDto> GetOrderDtos()
        {
            return _mediator.Send(new GetOrderByDateQuery(DateTime.Now, DateTime.Now.AddDays(-30))).Result;
        }
    }
}
