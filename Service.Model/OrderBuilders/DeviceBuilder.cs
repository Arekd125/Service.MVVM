using Serwis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Model.OrderBuilder
{
    public class DeviceBuilder
    {
        private Device _device = new Device();

        public DeviceBuilder(string deviceName, ModelDevice model)
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