﻿namespace Servis.Models.OrderModels
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Order> Order { get; set; }
    }
}