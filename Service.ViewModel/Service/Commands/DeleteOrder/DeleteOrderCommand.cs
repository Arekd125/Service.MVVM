using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.DeleteOrder
{
    public class DeleteOrderCommand : OrderDto, IRequest
    {

        public DeleteOrderCommand(string orderName)
        {
            OrderName = orderName;
        }
    }
}