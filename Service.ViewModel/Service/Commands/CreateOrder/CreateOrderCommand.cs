using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.CreateOrder
{
    public class CreateOrderCommand : OrderDto, IRequest
    {
    }
}