using MediatR;
using Service.Model.Repositories;

namespace Service.ViewModel.Service.Commands.DeleteDevice
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
    {
        private readonly IDeviceStateRepository _deviceStateRepository;

        public DeleteDeviceCommandHandler(IDeviceStateRepository deviceStateRepository)
        {
            _deviceStateRepository = deviceStateRepository;
        }

        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            await _deviceStateRepository.DeleteDevice(request.DeviceStateName);

            return Unit.Value;
        }
    }
}