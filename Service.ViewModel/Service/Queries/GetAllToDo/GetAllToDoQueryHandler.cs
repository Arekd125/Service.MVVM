using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetAllToDo
{
    public class GetAllToDoQueryHandler : IRequestHandler<GetAllToDoQuery, IEnumerable<ToDoDto>>
    {
        private readonly IToDoStateRepository _toDoRepository;
        private readonly IMapper _mapper;

        public GetAllToDoQueryHandler(IToDoStateRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoDto>> Handle(GetAllToDoQuery request, CancellationToken cancellationToken)
        {
            var toDoState = await _toDoRepository.GetAllToDoState();

            var toDoDto = _mapper.Map<IEnumerable<ToDoDto>>(toDoState);

            return toDoDto;
        }
    }
}