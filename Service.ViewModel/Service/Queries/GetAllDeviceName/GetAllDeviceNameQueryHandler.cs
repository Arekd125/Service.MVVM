using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetAllDeviceName
{
    public class GetAllDeviceNameQueryHandler : IRequestHandler<GetAllDeviceNameQuery, IEnumerable<string>>
    {
        private readonly IDeviceStateRepository _deviceStateRepository;

        public GetAllDeviceNameQueryHandler(IDeviceStateRepository deviceStateRepository)
        {
            _deviceStateRepository = deviceStateRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetAllDeviceNameQuery request, CancellationToken cancellationToken)
        {
            var allDevice = await _deviceStateRepository.GetAllDevice();
            return allDevice.Select(p => p.Name);
        }
    }
}