using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderModels
{
    public class Device
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Model Model { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}