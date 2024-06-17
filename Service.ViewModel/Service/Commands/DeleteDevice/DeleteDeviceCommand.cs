using MediatR;

namespace Service.ViewModel.Service.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest
    {
        public string DeviceStateName { get; }

        public DeleteDeviceCommand(string deviceStateName)
        {
            DeviceStateName = deviceStateName;
        }
    }
}