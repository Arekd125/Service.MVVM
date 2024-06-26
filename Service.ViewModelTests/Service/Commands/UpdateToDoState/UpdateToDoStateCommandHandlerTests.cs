using FluentAssertions;
using MediatR;
using Moq;
using Service.Model.Entity;
using Service.Model.Repositories;
using Xunit;

namespace Service.ViewModel.Service.Commands.UpdateToDoState.Tests
{
    public class UpdateToDoStateCommandHandlerTests
    {
        private readonly Mock<IToDoStateRepository> _todoStateRepositoryMock;
        private readonly UpdateToDoStateCommandHandler _handle;

        public UpdateToDoStateCommandHandlerTests()
        {
            _todoStateRepositoryMock = new Mock<IToDoStateRepository>();
            _handle = new UpdateToDoStateCommandHandler(_todoStateRepositoryMock.Object);
        }



        [Fact()]
        public async Task Handle_ShouldUpdateToDoState_WhenToDoStateExistAndToDoNameIsNotNullOrEmpty()
        {
            // Arrange

            var command = new UpdateToDoStateCommand()
            {
                Id = 2,
                ToDoName = "Test command",
                Prize = 23
            };

            ToDoState toDoState = new ToDoState()
            {
                ToDoName = "Test",
                Price = 12,

            };

            _todoStateRepositoryMock.Setup(s => s.GetById(command.Id)).ReturnsAsync(toDoState);
            _todoStateRepositoryMock.Setup(s => s.UpDate(toDoState)).Returns(Task.CompletedTask);

            // Act

            var result = await _handle.Handle(command, CancellationToken.None);

            // Assert

            result.Should().Be(Unit.Value);
            toDoState.Should().NotBeNull();
            toDoState.ToDoName.Should().Be(command.ToDoName);
            toDoState.Price.Should().Be(command.Prize);
            _todoStateRepositoryMock.Verify(ver => ver.UpDate(toDoState), Times.Once());

        }
        [Fact()]
        public async Task Handle_ShouldDosNotUpdateToDoState_WhenToDoStateDosNotExist()
        {
            // Arrange

            var command = new UpdateToDoStateCommand()
            {
                ToDoName = "Test command",
                Prize = 23
            };

            _todoStateRepositoryMock.Setup(s => s.GetById(command.Id)).ReturnsAsync((ToDoState)null);
            _todoStateRepositoryMock.Setup(s => s.UpDate(It.IsAny<ToDoState>())).Returns(Task.CompletedTask);

            // Act

            var result = await _handle.Handle(command, CancellationToken.None);

            // Assert

            result.Should().Be(Unit.Value);
            _todoStateRepositoryMock.Verify(ver => ver.UpDate(It.IsAny<ToDoState>()), Times.Never());

        }
        [Fact()]
        public async Task Handle_ShouldDosNotUpdateToDoState_WhenToDoStateToDoNameIsNull()
        {
            // Arrange

            var command = new UpdateToDoStateCommand()
            {

                Id = 2
            };

            ToDoState toDoState = new ToDoState();


            _todoStateRepositoryMock.Setup(s => s.GetById(command.Id)).ReturnsAsync(toDoState);
            _todoStateRepositoryMock.Setup(s => s.UpDate(It.IsAny<ToDoState>())).Returns(Task.CompletedTask);

            // Act

            var result = await _handle.Handle(command, CancellationToken.None);

            // Assert

            result.Should().Be(Unit.Value);
            toDoState.ToDoName.Should().BeNull();
            _todoStateRepositoryMock.Verify(ver => ver.UpDate(It.IsAny<ToDoState>()), Times.Never());

        }
        [Fact]
        public async Task Handle_ShouldDosNotUpdateToDoState_WhenToDoStateToDoNameIsEmpty()
        {
            // Arrange

            var command = new UpdateToDoStateCommand()
            {

                Id = 2
            };

            ToDoState toDoState = new ToDoState()
            {
                ToDoName = "",
            };


            _todoStateRepositoryMock.Setup(s => s.GetById(command.Id)).ReturnsAsync(toDoState);
            _todoStateRepositoryMock.Setup(s => s.UpDate(It.IsAny<ToDoState>())).Returns(Task.CompletedTask);

            // Act

            var result = await _handle.Handle(command, CancellationToken.None);

            // Assert

            result.Should().Be(Unit.Value);
            toDoState.ToDoName.Should().BeEmpty();
            _todoStateRepositoryMock.Verify(ver => ver.UpDate(It.IsAny<ToDoState>()), Times.Never());

        }
    }

}