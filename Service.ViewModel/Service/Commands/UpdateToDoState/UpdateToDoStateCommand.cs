using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.UpdateToDoState
{
    public class UpdateToDoStateCommand : ToDoStateDto, IRequest
    {
    }
}