using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Dtos
{
    public class ContactDto
    {
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public List<Order> Order { get; set; } = new List<Order>();
    }
}