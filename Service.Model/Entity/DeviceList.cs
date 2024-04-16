using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderModels
{
    public class DeviceList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModelList> ModelLists { get; set; } = new List<ModelList>();
    }
}