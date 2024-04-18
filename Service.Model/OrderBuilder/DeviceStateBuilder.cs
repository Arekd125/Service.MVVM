using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderBuilder
{
    public class DeviceStateBuilder
    {
        private DeviceState _device = new DeviceState();

        public DeviceStateBuilder(string deviceName, List<ModelState> model)
        {
            _device.Name = deviceName;
            _device.ModelLists = model;
        }

        public DeviceState Build()
        {
            return _device;
        }
    }
}