using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Service.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.DeleteToDoState
{
    public class DeleteToDoStateCommandHandler : IRequestHandler<DeleteToDoStateCommand>

    {
        private readonly IToDoStateRepository _toDoStateRepository;

        public DeleteToDoStateCommandHandler(IToDoStateRepository toDoStateRepository)
        {
            _toDoStateRepository = toDoStateRepository;
        }

        public async Task<Unit> Handle(DeleteToDoStateCommand request, CancellationToken cancellationToken)
        {
            var toDoState = _toDoStateRepository.GetById(request.Id).Result;

            if (toDoState != null)
            {
                await _toDoStateRepository.Remove(toDoState);
            }

            return Unit.Value;
        }
    }
}