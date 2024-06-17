using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetAllToDoState
{
    public class GetAllToDoStateQueryHandler : IRequestHandler<GetAllToDoStateQuery, IEnumerable<ToDoStateDto>>

    {
        private readonly IToDoStateRepository _toDoRepository;
        private readonly IMapper _mapper;

        public GetAllToDoStateQueryHandler(IToDoStateRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoStateDto>> Handle(GetAllToDoStateQuery request, CancellationToken cancellationToken)
        {
            var toDoState = await _toDoRepository.GetAllToDoState();

            var toDoDto = _mapper.Map<IEnumerable<ToDoStateDto>>(toDoState);

            return toDoDto;
        }
    }
}