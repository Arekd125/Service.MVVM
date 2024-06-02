namespace Servis.Models.OrderModels
{
    public class Contact
    {
        public int Id { get; set; } 
        public string? Name { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public List<Order> Order { get; set; } = new List<Order>();
    }
}