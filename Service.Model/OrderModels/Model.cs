using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderModels
{
    public class Model
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Device Device { get; set; }
        public Guid DeviceId { get; set; }
    }
}