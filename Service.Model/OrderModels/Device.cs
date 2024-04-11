using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.Models.OrderModels
{
    public class Device
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ModelDevice Model { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}