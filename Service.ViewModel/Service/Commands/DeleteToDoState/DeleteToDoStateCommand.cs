using MediatR;

namespace Service.ViewModel.Service.Commands.DeleteToDoState
{
    public class DeleteToDoStateCommand : IRequest
    {
        public int Id { get; }

        public DeleteToDoStateCommand(int id)
        {
            Id = id;
        }
    }
}