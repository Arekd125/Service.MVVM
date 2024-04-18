using Service.Model.Services.ServicesDevice;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public class ServiceDeviceState
    {
        private readonly IDeviceProvider _deviceProvider;

        public ServiceDeviceState(IDeviceProvider deviceProvider)
        {
            _deviceProvider = deviceProvider;
        }

        public IEnumerable<String> GetDeviceName()
        {
            return _deviceProvider.GetAllDevice().Result.Select(p => p.Name);
        }
    }
}