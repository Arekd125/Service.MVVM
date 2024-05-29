using MediatR;
using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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