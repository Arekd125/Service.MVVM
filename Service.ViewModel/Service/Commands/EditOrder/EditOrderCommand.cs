using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.EditOrder
{
    public class EditOrderCommand : OrderDto, IRequest
    {
    }
}
