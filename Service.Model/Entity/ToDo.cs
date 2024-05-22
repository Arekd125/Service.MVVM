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
        public int Id { get; set; }
        public string ToDoName { get; set; }
        public decimal Prize { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}