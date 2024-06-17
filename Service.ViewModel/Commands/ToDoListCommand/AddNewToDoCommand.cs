using AutoMapper;
using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Commands.CreateToDoState;
using Service.ViewModel.Service.Commands.UpdateToDoState;
using Service.ViewModel.Stores;

namespace Service.ViewModel.Commands.ToDoListCommand
{
    public class AddNewToDoCommand : CommandBase
    {
        private readonly ToDoStore _toDoStore;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AddNewToDoCommand(IMediator mediator, IMapper mapper, ToDoStore toDoStore)
        {
            _mediator = mediator;
            _mapper = mapper;
            _toDoStore = toDoStore;
        }

        public override void Execute(object? parameter)
        {
            ToDoStateDto toDoStatDto = parameter as ToDoStateDto;
            if (toDoStatDto != null)
            {
                if (toDoStatDto.Id == 0)
                {
                    CreateToDoStateCommand CreateCommand = _mapper.Map<CreateToDoStateCommand>(toDoStatDto);
                    _mediator.Send(CreateCommand);
                }
                else
                {
                    UpdateToDoStateCommand UpDateCommand = _mapper.Map<UpdateToDoStateCommand>(toDoStatDto);
                    _mediator.Send(UpDateCommand);
                }

                _toDoStore.AddTodo();
            }
        }
    }
}