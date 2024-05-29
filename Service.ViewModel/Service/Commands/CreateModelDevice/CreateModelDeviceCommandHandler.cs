using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Commands.CreateDevice;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.CreateModelDevice
{
    public class CreateModelDeviceCommandHandler : IRequestHandler<CreateModelDeviceCommand>
    {
        private readonly IDeviceStateRepository _deviceStateRepository;
        private readonly IMapper _mapper;

        public CreateModelDeviceCommandHandler(IDeviceStateRepository deviceStateRepository, IMapper mapper)
        {
            _deviceStateRepository = deviceStateRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateModelDeviceCommand request, CancellationToken cancellationToken)
        {
            var modelState = _mapper.Map<ModelState>(request.ModelStateDto);
            await _deviceStateRepository.AddModel(modelState, request.DeviceStateName);

            return Unit.Value;
        }
    }
}