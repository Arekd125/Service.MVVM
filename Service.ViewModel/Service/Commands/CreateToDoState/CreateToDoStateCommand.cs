using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.CreateToDoState
{
    public class CreateToDoStateCommand : ToDoStateDto, IRequest
    {
    }
}