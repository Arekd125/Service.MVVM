using MediatR;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Commands.CreateDevice
{
    public class CreateDeviceCommand : DeviceStateDto, IRequest
    {
    }
}