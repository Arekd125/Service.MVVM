namespace Service.ViewModel.Dtos
{
    public class CreateOrderDto
    {
        public int OrderNo { get; set; }
        public string OrderName { get; set; }
        public string? ContactName { get; set; }
        public string ContactPhoneNumber { get; set; } = default;
        public string Device { get; set; } = default;
        public string Model { get; set; } = default;
        public string? Description { get; set; }
        public string? ToDo { get; set; }
        public string? Accessories { get; set; }
    }
}