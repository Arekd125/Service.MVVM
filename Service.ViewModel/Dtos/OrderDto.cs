namespace Service.ViewModel.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int OrderNo { get; set; } = default!;
        public string OrderName { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public string? ContactName { get; set; } = default!;
        public string ContactPhoneNumber { get; set; } = default!;
        public string Device { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public List<ToDoDto> ToDo { get; set; } = new List<ToDoDto>();
        public decimal Cost { get; set; } = default!;
        public string? Accessories { get; set; } = default!;
        public bool IsFinished { get; set; }
    }
}