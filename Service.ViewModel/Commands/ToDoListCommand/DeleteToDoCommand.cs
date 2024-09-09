using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Commands.DeleteToDoState;
using Service.ViewModel.Stores;

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

            ToDoStateDto toDoDto = parameter as ToDoStateDto;

            if (toDoDto != null)
            {

                _mediator.Send(new DeleteToDoStateCommand(toDoDto.Id));
                _toDoStore.DeleteTodo();


            }   
        }
    }
}