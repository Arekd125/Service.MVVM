using Service.Model.Services.ServicesDevice;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Service
{
    public class ServiceDeviceState
    {
        private readonly IDeviceProvider _deviceProvider;
        private readonly IDeviceCreator _deviceCreator;

        public ServiceDeviceState(IDeviceProvider deviceProvider, IDeviceCreator deviceCreator)
        {
            _deviceProvider = deviceProvider;
            _deviceCreator = deviceCreator;
        }

        public IEnumerable<string> GetAllDeviceName()
        {
            var allDevice = _deviceProvider.GetAllDevice().Result.Select(p => p.Name);
            return allDevice;
        }

        public IEnumerable<string> GetAllModelName(string deviceName)

        {
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = _deviceProvider.GetDevice(deviceName).Result;
                return device.ModelLists.Select(p => p.Name);
            }
            return Enumerable.Empty<string>();
        }

        public void CreateDevice(DeviceState deviceName)
        {
            _deviceCreator.CreateDevice(deviceName);
        }
    }
}