using Service.Model.Entity;

namespace Servis.Models.OrderModels
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; } = default!;
        public string OrderName { get; set; } = default!;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public Contact? Contact { get; set; } = default!;
        public int ContactId { get; set; } = default!;
        public string Device { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public List<ToDo> ToDo { get; set; } = new List<ToDo>();
        public string? Accessories { get; set; } = default!;
        public decimal? Cost { get; set; } = default!;
        public Status OrderStatus { get; set; } = Status.started;
    }
}