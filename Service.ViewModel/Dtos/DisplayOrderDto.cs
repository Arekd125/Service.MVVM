using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Dtos
{
    public class DisplayOrderDto
    {
        public string OrderName { get; set; }
        public string StartData { get; set; }
        public string? ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Device { get; set; }
        public string Model { get; set; }
    }
}