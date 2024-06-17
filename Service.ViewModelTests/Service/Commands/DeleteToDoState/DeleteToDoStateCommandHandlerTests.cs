using FluentAssertions;
using MediatR;
using Moq;
using Service.Model.Entity;
using Service.Model.Repositories;
using Xunit;

namespace Service.ViewModel.Service.Commands.DeleteToDoState.Tests
{
    public class DeleteToDoStateCommandHandlerTests
    {
        private readonly Mock<IToDoStateRepository> _todoStateRepositoryMock;
        private readonly DeleteToDoStateCommandHandler _handle;

        public DeleteToDoStateCommandHandlerTests()
        {
            _todoStateRepositoryMock = new Mock<IToDoStateRepository>();
            _handle = new DeleteToDoStateCommandHandler(_todoStateRepositoryMock.Object);
        }

        [Fact()]
        public async Task Handle_ShouldDeleteToDoState_WhenToDoStateExist()
        {
            // Arrange 

            var command = new DeleteToDoStateCommand(1);

            ToDoState toDoState = new ToDoState()
            {
                Id = 1,

            };

            _todoStateRepositoryMock.Setup(s => s.GetById(command.Id)).ReturnsAsync(toDoState);
            _todoStateRepositoryMock.Setup(s => s.Remove(It.IsAny<ToDoState>())).Returns(Task.CompletedTask);

            // Act


            var result = await _handle.Handle(command, CancellationToken.None);


            // Assert

            result.Should().Be(Unit.Value);
            _todoStateRepositoryMock.Verify(v => v.Remove(It.IsAny<ToDoState>()), Times.Once);


        }
        [Fact()]
        public async Task Handle_ShouldDosNotDeleteToDoState_WhenToDoStateDosNotExist()
        {
            // Arrange 

            var command = new DeleteToDoStateCommand(1);

            _todoStateRepositoryMock.Setup(s => s.GetById(command.Id)).ReturnsAsync((ToDoState)null);
            _todoStateRepositoryMock.Setup(s => s.Remove(It.IsAny<ToDoState>())).Returns(Task.CompletedTask);

            // Act


            var result = await _handle.Handle(command, CancellationToken.None);


            // Assert

            result.Should().Be(Unit.Value);
            _todoStateRepositoryMock.Verify(v => v.Remove(It.IsAny<ToDoState>()), Times.Never);


        }
    }
}