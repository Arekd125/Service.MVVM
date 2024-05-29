using MediatR;
using Service.Model.Entity;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Commands.DeleteToDoState;
using Service.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.ToDoListCommand
{
    public class DeleteToDoCommand : CommandBase
    {
        private readonly ToDoStore _toDoStore;
        private readonly IMediator _mediator;

        public DeleteToDoCommand(IMediator mediator, ToDoStore toDoStore)
        {
            _toDoStore = toDoStore;
            _mediator = mediator;
        }

        public override void Execute(object? parameter)
        {
            ToDoStateDto toDoDto = (ToDoStateDto)parameter;
            //  _orderService.DeleteToDoState(toDoDto.Id);
            _mediator.Send(new DeleteToDoStateCommand(toDoDto.Id));

            _toDoStore.DeleteTodo();
        }
    }
}