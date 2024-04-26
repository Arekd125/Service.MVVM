using Servis.Models.OrderModels;

namespace Service.ViewModel.Dtos
{
    public class DeviceStateDto
    {
        public string? Name { get; set; }
        public List<ModelState> ModelLists { get; set; } = new List<ModelState>();
    }
}