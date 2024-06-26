using MediatR;
using Service.Model.Repositories;

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
                toDoStateUpdate.Price = request.Prize;
                await _toDoStateRepository.UpDate(toDoStateUpdate);
            }
            return Unit.Value;
        }
    }
}