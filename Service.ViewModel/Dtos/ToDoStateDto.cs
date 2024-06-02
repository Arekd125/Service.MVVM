using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Dtos
{
    public class ToDoStateDto
    {
        public int Id { get; set; } = default!;
        public string ToDoName { get; set; } = default!;
        public decimal Prize { get; set; } = default!;
    }
}