using AutoMapper;
using MediatR;
using Service.Model.Entity;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.UpdateToDoState
{
    public class UpdateToDoStateCommandHandler : IRequestHandler<UpdateToDoStateCommand>
    {
        private readonly IToDoStateRepository _toDoStateRepository;
        private readonly IMapper _mapper;

        public UpdateToDoStateCommandHandler(IToDoStateRepository toDoStateRepository, IMapper mapper)
        {
            _toDoStateRepository = toDoStateRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateToDoStateCommand request, CancellationToken cancellationToken)
        {
            var toDoState = _mapper.Map<ToDoState>(request);

            await _toDoStateRepository.UpDate(toDoState);
            return Unit.Value;
        }
    }
}