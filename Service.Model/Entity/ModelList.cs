using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderModels
{
    public class ModelList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceList DeviceList { get; set; }
        public int DeviceListId { get; set; }
    }
}