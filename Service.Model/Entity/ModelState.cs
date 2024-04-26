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