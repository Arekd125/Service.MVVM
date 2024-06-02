using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.Entity
{
    public class ToDoState
    {
        public int Id { get; set; } = default!;
        public string ToDoName { get; set; }  = default!;
        public decimal Prize { get; set; } = default!;
    }
}