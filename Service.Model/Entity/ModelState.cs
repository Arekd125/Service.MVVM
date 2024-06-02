namespace Servis.Models.OrderModels
{
    public class ModelState
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DeviceState DeviceState { get; set; } = default!;
        public int DeviceStateId { get; set; } = default!;
    }
}