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

        public IEnumerable<string> GetAllDeviceName()
        {
            var allDevice = _deviceRepository.GetAllDevice().Result.Select(p => p.Name);
            return allDevice;
        }

        public IEnumerable<string> GetAllModelName(string deviceName)

        {
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = _deviceRepository.GetDevice(deviceName).Result;
                return device.ModelLists.Select(p => p.Name);
            }
            return Enumerable.Empty<string>();
        }

        public void CreateDevice(DeviceState deviceName)
        {
            _deviceRepository.CreateDevice(deviceName);
        }
    }
}