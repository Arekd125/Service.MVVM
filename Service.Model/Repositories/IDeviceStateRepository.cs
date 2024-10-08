﻿using Servis.Models.OrderModels;

namespace Service.Model.Repositories
{
    public interface IDeviceStateRepository
    {
        public Task CreateDevice(DeviceState deviceState);

        public Task<DeviceState> GetDevice(string deviceName);

        public Task<IEnumerable<DeviceState>> GetAllDevice();

        public Task AddModel(ModelState modelState, string deviceStateName);

        public Task DeleteDevice(string deviceStateName);

        public Task DeleteModel(string deviceStateName, string modeleStateName);
    }
}