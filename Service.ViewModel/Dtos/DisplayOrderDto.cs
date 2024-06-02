namespace Service.ViewModel.Dtos
{
    public class DisplayOrderDto
    {
        public string OrderName { get; set; } = default!;  
        public string StartData { get; set; } = default!;
        public string? ContactName { get; set; } = default!; 
        public string ContactPhoneNumber { get; set; } = default!;  
        public string Device { get; set; } = default!; 
        public string Model { get; set; } = default!;  
    }
}