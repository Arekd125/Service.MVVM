using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.CreateToDoState
{
    public class CreateToDoStateCommand : ToDoStateDto, IRequest
    {
        public CreateToDoStateCommand(ToDoStateDto toDoStateDto)
        {
            Id = toDoStateDto.Id;
            ToDoName = toDoStateDto.ToDoName;
            Prize = toDoStateDto.Prize;
        }
    }
}