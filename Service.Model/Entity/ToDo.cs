using Servis.Models.OrderModels;

namespace Service.Model.Entity
{
    public class ToDo
    {
        public int Id { get; set; } = default!;
        public string ToDoName { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Order Order { get; set; } = default!;
        public int OrderId { get; set; } = default!;
    }
}