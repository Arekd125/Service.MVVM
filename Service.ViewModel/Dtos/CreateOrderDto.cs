using Service.Model.Entity;

namespace Service.ViewModel.Dtos
{
    public class CreateOrderDto
    {
        public int OrderNo { get; set; }
        public string? OrderName { get; set; }
        public string? Device { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public List<ToDoStateDto> ToDo { get; set; } = new List<ToDoStateDto>();
        public string? Accessories { get; set; }
    }
}