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
        private DeviceList _device = new DeviceList();

        public DeviceBuilder(string deviceName, List<ModelList> model)
        {
            _device.Name = deviceName;
            _device.ModelLists = model;
        }

        public DeviceList Build()
        {
            return _device;
        }
    }
}