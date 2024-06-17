using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetAllToDo
{
    public class GetAllToDoQuery : IRequest<IEnumerable<ToDoDto>>
    {
    }
}