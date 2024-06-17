using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
    }
}