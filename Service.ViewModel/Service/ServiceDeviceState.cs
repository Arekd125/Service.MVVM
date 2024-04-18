using Service.Model.Services.ServicesDevice;

namespace Service.ViewModel.Service
{
    public class ServiceDeviceState
    {
        private readonly IDeviceProvider _deviceProvider;

        public ServiceDeviceState(IDeviceProvider deviceProvider)
        {
            _deviceProvider = deviceProvider;
        }

        public IEnumerable<String> GetAllDeviceName()
        {
            var allDevice = _deviceProvider.GetAllDevice().Result.Select(p => p.Name);
            return allDevice;
        }

        public IEnumerable<String> GetAllModelName(string deviceName)

        {
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = _deviceProvider.GetDevice(deviceName).Result;
                return device.ModelLists.Select(p => p.Name);
            }
            return Enumerable.Empty<String>();
        }
    }
}