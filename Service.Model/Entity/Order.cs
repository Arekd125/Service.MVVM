using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderModels
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public string OrderName { get; set; }
        public DateTime StartDate { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public string? Device { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? ToDo { get; set; }
        public string? Accessories { get; set; }
    }
}