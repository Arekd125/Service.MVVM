using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Dtos
{
    public class ToDoStatsDto
    {
        public int Id { get; set; }
        public string ToDoName { get; set; }
        public decimal Prize { get; set; }
    }
}