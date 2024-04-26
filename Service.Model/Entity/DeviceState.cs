namespace Servis.Models.OrderModels
{
    public class DeviceState
    {
        public int Id { get; set; } 
        public string Name { get; set; } =  string.Empty;
        public List<ModelState> ModelLists { get; set; } = new List<ModelState>();
    }
}