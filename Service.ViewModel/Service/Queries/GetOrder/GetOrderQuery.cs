using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public string OrderName { get; }

        public GetOrderQuery(string orderName)
        {
            OrderName = orderName;
        }
    }
}