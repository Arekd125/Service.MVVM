using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services.ServicesDevice
{
    public interface IDeviceCreator
    {
        public Task CreateDevice(DeviceState deviceState);
    }
}