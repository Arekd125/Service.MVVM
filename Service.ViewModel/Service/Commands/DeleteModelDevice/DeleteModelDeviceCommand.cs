using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.DeleteModelDevice
{
    public class DeleteModelDeviceCommand : IRequest
    {
        public string DeviceStateName { get; }
        public string ModeleStateName { get; }

        public DeleteModelDeviceCommand(string deviceStateName, string modeleStateName)
        {
            DeviceStateName = deviceStateName;
            ModeleStateName = modeleStateName;
        }
    }
}