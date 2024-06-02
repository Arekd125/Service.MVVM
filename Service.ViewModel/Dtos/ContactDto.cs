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
        public string? ContactName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public List<Order> Order { get; set; } = new List<Order>();
    }
}