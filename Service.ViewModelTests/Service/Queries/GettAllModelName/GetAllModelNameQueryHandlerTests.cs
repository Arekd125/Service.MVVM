using FluentAssertions;
using Moq;
using Service.Model.Repositories;
using Servis.Models.OrderModels;
using Xunit;

namespace Service.ViewModel.Service.Queries.GettAllModelName.Tests
{
    public class GetAllModelNameQueryHandlerTests
    {
        private readonly Mock<IDeviceStateRepository> _deviceStateRepositoryMock;
        private readonly GetAllModelNameQueryHandler _handler;

        public GetAllModelNameQueryHandlerTests()
        {
            _deviceStateRepositoryMock = new Mock<IDeviceStateRepository>();
            _handler = new GetAllModelNameQueryHandler(_deviceStateRepositoryMock.Object);
        }


        [Fact()]
        public async Task Handle_ShouldReturnListOfModelDeviceNames_WhenDeviceNameIsNotNullOrEmpty()
        {
            // Arrange
            var query = new GetAllModelNameQuery("Device");

            List<ModelState> modelList = new()
            {
                 new() { Name="Model1"},
                 new() { Name="Model2"},
                 new() { Name="Model3"}
            };

            DeviceState device = new DeviceState()
            {
                Name = "Device",
                ModelLists = modelList
            };

            _deviceStateRepositoryMock.Setup(s => s.GetDevice(It.IsAny<string>())).ReturnsAsync(device);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert

            _deviceStateRepositoryMock.Verify(ver => ver.GetDevice(It.IsAny<string>()), Times.Once());
            result.Should().Equal(modelList.Select(p => p.Name));

        }

        [Fact()]
        public async Task Handle_ShouldReturnEmptyListofString_WhenDeviceNameIsEmpty()
        {
            // Arrange
            var query = new GetAllModelNameQuery("");

            List<ModelState> modelList = new()
            {
                 new() { Name="Model1"},
                 new() { Name="Model2"},
                 new() { Name="Model3"}
            };

            DeviceState device = new DeviceState()
            {
                Name = "Device",
                ModelLists = modelList
            };

            _deviceStateRepositoryMock.Setup(s => s.GetDevice(It.IsAny<string>())).ReturnsAsync(device);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert

            _deviceStateRepositoryMock.Verify(ver => ver.GetDevice(It.IsAny<string>()), Times.Never());
            result.Should().Equal(Enumerable.Empty<string>());

        }

        [Fact()]
        public async Task Handle_ShouldReturnEmptyListofString_WhenDeviceNameDosNotExist()
        {

            // Arrange


            GetAllModelNameQuery query = new(null);

            List<ModelState> modelList = new()
            {
                 new() { Name="Model1"},
                 new() { Name="Model2"},
                 new() { Name="Model3"}
            };

            DeviceState device = new DeviceState()
            {
                Name = "Device",
                ModelLists = modelList
            };

            _deviceStateRepositoryMock.Setup(s => s.GetDevice(It.IsAny<string>())).ReturnsAsync(device);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert

            _deviceStateRepositoryMock.Verify(ver => ver.GetDevice(It.IsAny<string>()), Times.Never());
            result.Should().Equal(Enumerable.Empty<string>());

        }
    }
}