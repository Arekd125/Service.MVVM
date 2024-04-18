using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly Order _order;

        public string OrderName => _order.OrderName;
        public string StartData => _order.StartDate.ToString("d");
        public string? ContactName => _order.Contact.Name;
        public string ContactPhoneNumber => _order.Contact.PhoneNumber;
        public string DeviceName => _order.Device;
        public string DeviceModelName => _order.Model;

        public OrdersViewModel(Order order)
        {
            _order = order;
        }
    }
}