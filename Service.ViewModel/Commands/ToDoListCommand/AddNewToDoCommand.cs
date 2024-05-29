using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Commands.CreateToDoState;
using Service.ViewModel.Service.Commands.UpdateToDoState;
using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Service.ViewModel.Commands.ToDoListCommand
{
    public class AddNewToDoCommand : CommandBase
    {
        private readonly ToDoStore _toDoStore;
        private readonly IMediator _mediator;

        public AddNewToDoCommand(IMediator mediator, ToDoStore toDoStore)
        {
            _mediator = mediator;
            _toDoStore = toDoStore;
        }

        public override void Execute(object? parameter)
        {
            ToDoStateDto toDo = parameter as ToDoStateDto;
            if (toDo != null)
            {
                if (toDo.Id == 0)
                {
                    _mediator.Send(new CreateToDoStateCommand(toDo));
                    //_orderService.CreateToDoState(toDo);
                }
                else
                {
                    _mediator.Send(new UpdateToDoStateCommand(toDo));
                    // _orderService.UpdateToDoState(toDo);
                }

                _toDoStore.AddTodo();
            }
        }
    }
}