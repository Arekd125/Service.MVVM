using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Entity
{
    public class ToDo
    {
        public int Id { get; set; } = default!;
        public string ToDoName { get; set; } = default!;
        public decimal Prize { get; set; } = default!;
        public Order Order { get; set; } = default!;
        public int OrderId { get; set; } = default!;
    }
}