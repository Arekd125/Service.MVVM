using Service.ViewModel.Service;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class DeviceStateAndModelStateViewModel
    {
        private readonly IDeviceStateService _deviceStateService;
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public DeviceStateAndModelStateViewModel(CreatingOrderViewModel creatingOrderViewModel, IDeviceStateService deviceStateService)
        {
            _deviceStateService = deviceStateService;
            _creatingOrderViewModel = creatingOrderViewModel;
        }
    }
}