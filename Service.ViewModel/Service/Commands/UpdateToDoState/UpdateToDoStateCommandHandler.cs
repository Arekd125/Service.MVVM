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
 
        public UpdateToDoStateCommandHandler(IToDoStateRepository toDoStateRepository)
        {
            _toDoStateRepository = toDoStateRepository;
         
        }

        public async Task<Unit> Handle(UpdateToDoStateCommand request, CancellationToken cancellationToken)
        {
            var toDoStateUpdate = await _toDoStateRepository.GetById(request.Id);
            var isEditable = (toDoStateUpdate != null && !string.IsNullOrEmpty(request.ToDoName));

            if (isEditable)
            {
                toDoStateUpdate.ToDoName = request.ToDoName;
                toDoStateUpdate.Prize = request.Prize;
                await _toDoStateRepository.UpDate(toDoStateUpdate);
            }
            return Unit.Value;
        }
    }
}