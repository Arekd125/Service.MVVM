namespace Service.ViewModel.Dtos
{
    public class CreateOrderDto
    {
        public int OrderNo { get; set; }
        public string? OrderName { get; set; }
        public string? Device { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? ToDo { get; set; }
        public string? Accessories { get; set; }
    }
}