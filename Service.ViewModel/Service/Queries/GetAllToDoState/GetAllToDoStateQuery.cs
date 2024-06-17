using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetAllToDoState
{
    public class GetAllToDoStateQuery : IRequest<IEnumerable<ToDoStateDto>>
    {
    }
}