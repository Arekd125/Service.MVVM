using Xunit;
using Service.ViewModel.Service.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Service.Model.Repositories;
using Moq;
using Servis.Models.OrderModels;
using FluentAssertions;
using MediatR;

namespace Service.ViewModel.Service.Commands.CreateOrder.Tests
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IContactRepository> _contactRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateOrderCommandHandler _handler;

        public CreateOrderCommandHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _contactRepositoryMock = new Mock<IContactRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateOrderCommandHandler(_orderRepositoryMock.Object, _contactRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateOrderAndContact_WhenContactDoesNotExist()
        {
            // Arrange
            var command = new CreateOrderCommand
            {
                ContactName = "Test",
                ContactPhoneNumber = "111 111 111",
            };

            Order order = new()
            {
                Contact = new Contact
                {
                    Id = 1,
                    Name = "Name Test",
                    PhoneNumber = "111 111 111"
                },
                StartDate = DateTime.Now,
            };

            _mapperMock.Setup(m => m.Map<Order>(command)).Returns(order);
            _contactRepositoryMock.Setup(s => s.GetContact(order)).ReturnsAsync((Contact)null);
            _orderRepositoryMock.Setup(c => c.Create(order)).Returns(Task.CompletedTask);

            // Act

            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert

            result.Should().Be(Unit.Value);
            _orderRepositoryMock.Verify(c => c.Create(It.IsAny<Order>()), Times.Once());
        }

        [Fact()]
        public async Task Handle_ShouldAssignExistingContact_WhenContactExists()
        {
            // Arrange
            var command = new CreateOrderCommand
            {
                ContactName = "Test",
                ContactPhoneNumber = "111 111 111",
            };

            Order order = new()
            {
                Contact = new Contact
                {
                    Id = 1,
                    Name = "Name Test",
                    PhoneNumber = "111 111 111"
                },
                StartDate = DateTime.Now,
            };

            var existingContact = new Contact
            {
                Id = 2,
                Name = "Name Test",
                PhoneNumber = "111 111 111"
            };

            _mapperMock.Setup(m => m.Map<Order>(command)).Returns(order);
            _contactRepositoryMock.Setup(s => s.GetContact(order)).ReturnsAsync(existingContact);
            _orderRepositoryMock.Setup(c => c.Create(order)).Returns(Task.CompletedTask);

            // Act

            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert

            result.Should().Be(Unit.Value);
            existingContact.Should().NotBeNull();
            existingContact.Id.Should().Be(order.ContactId);
            //existingContact.Should().Be(order.Contact);
            _orderRepositoryMock.Verify(c => c.Create(It.IsAny<Order>()), Times.Once());
        }
    }
}