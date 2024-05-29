using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Service.Queries.GetAllDeviceName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GettAllModelName
{
    internal class GetAllModelNameQueryHandler : IRequestHandler<GetAllModelNameQuery, IEnumerable<string>>
    {
        private readonly IDeviceStateRepository _deviceStateRepository;

        public GetAllModelNameQueryHandler(IDeviceStateRepository deviceStateRepository)
        {
            _deviceStateRepository = deviceStateRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetAllModelNameQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.DeviceStateName))
            {
                var device = await _deviceStateRepository.GetDevice(request.DeviceStateName);
                return device.ModelLists.Select(p => p.Name);
            }
            return Enumerable.Empty<string>();
        }
    }
}