using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Services.ServicesDevice
{
    public interface IDeviceProvider
    {
        Task<DeviceState> GetDevice(int id);

        Task<DeviceState> GetDevice(string deviceName);

        Task<IEnumerable<DeviceState>> GetAllDevice();
    }
}