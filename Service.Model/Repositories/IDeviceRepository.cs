using Servis.Models.OrderModels;

namespace Service.Model.Repositories
{
    public interface IDeviceRepository
    {
        public Task CreateDevice(DeviceState deviceState);

        public Task<DeviceState> GetDevice(string deviceName);

        public Task<IEnumerable<DeviceState>> GetAllDevice();

        public Task AddModel(ModelState modelState, string deviceStateName);

        public Task DeleteDevice(string deviceStateName);
    }
}