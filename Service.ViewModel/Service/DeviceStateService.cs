using Service.Model.Repositories;

using Servis.Models.OrderModels;

namespace Service.ViewModel.Service
{
    public class DeviceStateService : IDeviceStateService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceStateService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<string>> GetAllDeviceName()
        {
            var allDevice = await _deviceRepository.GetAllDevice();
            return allDevice.Select(p => p.Name);
        }

        public async Task<IEnumerable<string>> GetAllModelName(string deviceName)

        {
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = await _deviceRepository.GetDevice(deviceName);
                return device.ModelLists.Select(p => p.Name);
            }
            return Enumerable.Empty<string>();
        }

        public async Task CreateDevice(DeviceState deviceName)
        {
            await _deviceRepository.CreateDevice(deviceName);
        }

        public async Task AddModel(ModelState modelState, string deviceStateName)
        {
            await _deviceRepository.AddModel(modelState, deviceStateName);
        }
    }
}