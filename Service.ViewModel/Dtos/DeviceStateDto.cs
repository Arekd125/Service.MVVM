using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Dtos
{
    public class DeviceStateDto
    {
        public string Name { get; set; }
        public List<ModelState> ModelLists { get; set; } = new List<ModelState>();
    }
}