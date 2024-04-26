using Servis.Models.OrderModels;

namespace Service.ViewModel.Service
{
    public interface IDeviceStateService
    {
        Task CreateDevice(DeviceState deviceName);

        Task AddModel(ModelState modelState, string deviceStateSelectedItem);

        Task<IEnumerable<string>> GetAllDeviceName();

        Task<IEnumerable<string>> GetAllModelName(string deviceName);
    }
}