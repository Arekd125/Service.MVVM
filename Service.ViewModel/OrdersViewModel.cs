using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly Order _order;

        public string OrderName => _order.OrderName;
        public string StartData => _order.StartDate.ToString("g");
        public string ContactName => _order.Contact.Name;
        public string ContactPhoneNumber => _order.Contact.PhoneNumber;
        public string DeviceName => _order.Device.Name;
        public string DeviceModelName => _order.Device.Model.Name;

        public OrdersViewModel(Order order)
        {
            _order = order;
        }
    }
}