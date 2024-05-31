using AutoMapper;
using MediatR;
using Service.Model.Entity;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using Service.ViewModel.Stores;
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
            var toDoStateUpdate = await _toDoStateRepository.GetById(request.Id);

            if (toDoStateUpdate != null && !string.IsNullOrEmpty(request.ToDoName))
            {
                toDoStateUpdate.ToDoName = request.ToDoName;
                toDoStateUpdate.Prize = request.Prize;
                await _toDoStateRepository.UpDate(toDoStateUpdate);
            }
            return Unit.Value;
        }
    }
}