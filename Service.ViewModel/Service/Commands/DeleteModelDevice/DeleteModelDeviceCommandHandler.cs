using MediatR;
using Service.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.DeleteModelDevice
{
    public class DeleteModelDeviceCommandHandler : IRequestHandler<DeleteModelDeviceCommand>
    {
        private readonly IDeviceStateRepository _deviceStateRepository;

        public DeleteModelDeviceCommandHandler(IDeviceStateRepository deviceStateRepository)
        {
            _deviceStateRepository = deviceStateRepository;
        }

        public async Task<Unit> Handle(DeleteModelDeviceCommand request, CancellationToken cancellationToken)
        {
            await _deviceStateRepository.DeleteModel(request.DeviceStateName, request.ModeleStateName);

            return Unit.Value;
        }
    }
}