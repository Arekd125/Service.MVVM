using Servis.Models.OrderModels;

namespace Service.ViewModel.Service
{
    public interface IDeviceStateService
    {
        void CreateDevice(DeviceState deviceName);
        IEnumerable<string> GetAllDeviceName();
        IEnumerable<string> GetAllModelName(string deviceName);
    }
}