using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.CreateModelDevice
{
    public class CreateModelDeviceCommand : IRequest
    {
        public ModelStateDto ModelStateDto { get; }
        public string DeviceStateName { get; }

        public CreateModelDeviceCommand(ModelStateDto modelStateDto, string deviceStateName)
        {
            ModelStateDto = modelStateDto;
            DeviceStateName = deviceStateName;
        }
    }
}