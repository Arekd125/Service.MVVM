using MediatR;
using Service.Model.Repositories;

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
            var toDoState = await _toDoStateRepository.GetById(request.Id);

            if (toDoState != null)
            {
                await _toDoStateRepository.Remove(toDoState);
            }

            return Unit.Value;
        }
    }
}