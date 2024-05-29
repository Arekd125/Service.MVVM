using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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