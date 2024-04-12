using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderBuilder
{
    public class DeviceBuilder
    {
        private Device _device = new Device();

        public DeviceBuilder(string deviceName, Model model)
        {
            _device.Name = deviceName;
            _device.Model = model;
        }

        public Device Build()
        {
            return _device;
        }
    }
}