using Service.Model.Repositories;

using Servis.Models.OrderModels;

namespace Service.ViewModel.Service
{
    public class DeviceStateService : IDeviceStateService
    {
        private readonly IDeviceStateRepository _deviceRepository;

        public DeviceStateService(IDeviceStateRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<string>> GetAllDeviceName()
        {
            var allDevice = await _deviceRepository.GetAllDevice();
            return allDevice.Select(p => p.Name);
        }

        public async Task<IEnumerable<string>> GetAllModelName(string deviceStateName)

        {
            if (!string.IsNullOrEmpty(deviceStateName))
            {
                var device = await _deviceRepository.GetDevice(deviceStateName);
                return device.ModelLists.Select(p => p.Name);
            }
            return Enumerable.Empty<string>();
        }

        public async Task CreateDevice(DeviceState deviceStateName)
        {
            await _deviceRepository.CreateDevice(deviceStateName);
        }

        public async Task AddModel(ModelState modelState, string deviceStateName)
        {
            await _deviceRepository.AddModel(modelState, deviceStateName);
        }

        public async Task DeleteDevice(string deviceStateName)
        {
            await _deviceRepository.DeleteDevice(deviceStateName);
        }

        public async Task DeleteModel(string deviceStateName, string modeleStateName)
        {
            await _deviceRepository.DeleteModel(deviceStateName, modeleStateName);
        }
    }
}