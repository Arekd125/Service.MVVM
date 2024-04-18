using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderModels
{
    public class ModelState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceState DeviceState { get; set; }
        public int DeviceStateId { get; set; }
    }
}