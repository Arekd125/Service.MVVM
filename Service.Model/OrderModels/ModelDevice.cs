using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.Models.OrderModels
{
    public class ModelDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Device Device { get; set; }
        public Guid DeviceId { get; set; }
    }
}