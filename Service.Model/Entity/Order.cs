using Service.Model.Entity;

namespace Servis.Models.OrderModels
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public string OrderName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
        public string Device { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<ToDo> ToDo { get; set; } = new List<ToDo>();
        public string? Accessories { get; set; }
    }
}