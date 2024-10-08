﻿using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Service.Commands.CreateDevice
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand>
    {
        private readonly IDeviceStateRepository _deviceStateRepository;
        private readonly IMapper _mapper;

        public CreateDeviceCommandHandler(IDeviceStateRepository deviceStateRepository, IMapper mapper)
        {
            _deviceStateRepository = deviceStateRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var deviceState = _mapper.Map<DeviceState>(request);
            await _deviceStateRepository.CreateDevice(deviceState);
            return Unit.Value;
        }
    }
}