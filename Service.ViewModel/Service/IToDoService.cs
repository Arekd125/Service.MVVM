using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public interface IToDoService
    {
        public Task Create(List<ToDoStateDto> toDoStateDtos, int OrderId);
    }
}