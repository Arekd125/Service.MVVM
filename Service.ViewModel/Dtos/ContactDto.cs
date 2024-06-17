using Servis.Models.OrderModels;

namespace Service.ViewModel.Dtos
{
    public class ContactDto
    {
        public string? ContactName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public List<Order> Order { get; set; } = new List<Order>();
    }
}