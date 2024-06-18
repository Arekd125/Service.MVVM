using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetOrderByDate;

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