using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Repositories
{
    public interface IDeviceRepository
    {
        public Task CreateDevice(DeviceState deviceState);

        public Task<DeviceState> GetDevice(string deviceName);

        public Task<IEnumerable<DeviceState>> GetAllDevice();

        public Task AddModel(ModelState modelState, string deviceStateName);
    }
}