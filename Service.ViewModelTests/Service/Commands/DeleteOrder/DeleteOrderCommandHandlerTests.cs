using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using Service.Model.Repositories;
using Servis.Models.OrderModels;
using Xunit;

namespace Service.ViewModel.Service.Commands.DeleteOrder.Tests
{
    public class DeleteOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IContactRepository> _contactRepositoryMock;
        private readonly DeleteOrderCommandHandler _handler;
        private readonly Mock<IMapper> _mapperMock;

        public DeleteOrderCommandHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _contactRepositoryMock = new Mock<IContactRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new DeleteOrderCommandHandler(_orderRepositoryMock.Object, _contactRepositoryMock.Object, _mapperMock.Object);

        }
        [Fact]
        public async Task Handle_OrderDoesNotExist_ReturnsUnitValue()
        {
            // Arrange
            var command = new DeleteOrderCommand("NonExistentOrder");
            _orderRepositoryMock.Setup(repo => repo.GetOrderByOrderName(It.IsAny<string>())).ReturnsAsync((Order)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);
        }

        [Fact]
        public async Task Handle_OrderExists_ContactUsedByOtherOrders_DoesNotDeleteContact()
        {
            // Arrange
            var command = new DeleteOrderCommand("ExistingOrder");
            var contact = new Contact { Id = 1, Name = "NameTest", PhoneNumber = "123 456 890" };
            var order = new Order { OrderName = "ExistingOrder", Contact = contact, ContactId = contact.Id };

            _orderRepositoryMock.Setup(repo => repo.GetOrderByOrderName(It.IsAny<string>())).ReturnsAsync(order);
            _orderRepositoryMock.Setup(repo => repo.AnyOrderWithContactId(contact.Id)).ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);
            _contactRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Contact>()), Times.Never);
        }

        [Fact]
        public async Task Handle_OrderExists_ContactNotUsedByOtherOrders_DeletesContact()
        {
            // Arrange
            var command = new DeleteOrderCommand("ExistingOrder");
            var contact = new Contact { Id = 1, Name = "NameTest", PhoneNumber = "123 456 890" };
            var order = new Order { OrderName = "ExistingOrder", Contact = contact, ContactId = contact.Id };

            _orderRepositoryMock.Setup(repo => repo.GetOrderByOrderName(It.IsAny<string>())).ReturnsAsync(order);
            _orderRepositoryMock.Setup(repo => repo.AnyOrderWithContactId(contact.Id)).ReturnsAsync(false);
            _contactRepositoryMock.Setup(repo => repo.Delete(contact)).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(Unit.Value);
            _contactRepositoryMock.Verify(repo => repo.Delete(contact), Times.Once);
        }
    }
}