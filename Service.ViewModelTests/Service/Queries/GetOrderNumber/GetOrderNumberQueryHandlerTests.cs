using FluentAssertions;
using Moq;
using Service.Model.Repositories;
using Servis.Models.OrderModels;
using Xunit;

namespace Service.ViewModel.Service.Queries.GetOrderNumber.Tests
{
    public class GetOrderNumberQueryHandlerTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly GetOrderNumberQueryHandler _handler;

        public GetOrderNumberQueryHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new GetOrderNumberQueryHandler(_orderRepositoryMock.Object);
        }


        [Fact()]
        public async Task Handle_ShouldReturnOrderNumber_One_WhenOrderDoesNotExist()
        {
            //Arrange
            var query = new GetOrderNumberQuery();

            _orderRepositoryMock.Setup(s => s.GetLastOrder()).ReturnsAsync((Order)null);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert

            result.Should().Be(1);
        }

        [Fact()]
        public async Task Handle_ShouldReturnOrderNumber_PlusOne_WhenLastOrderDataIsTheSameInCurrentMonthAndYear()
        {
            //Arrange
            var query = new GetOrderNumberQuery();

            Order order = new()
            {
                OrderNo = 101,
                StartDate = DateTime.Now,

            };

            _orderRepositoryMock.Setup(s => s.GetLastOrder()).ReturnsAsync(order);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert

            result.Should().Be(102);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        public async Task Handle_ShouldReturnOrderNumber_One_WhenLastOrderDataIsNotTheSameInCurrentMonthAndYear(int dateTimemothe)
        {
            //Arrange
            var query = new GetOrderNumberQuery();

            Order order = new()
            {
                OrderNo = 101,
                StartDate = DateTime.Now.AddMonths(dateTimemothe)

            };

            _orderRepositoryMock.Setup(s => s.GetLastOrder()).ReturnsAsync(order);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            //Assert

            result.Should().Be(1);
        }
    }
}