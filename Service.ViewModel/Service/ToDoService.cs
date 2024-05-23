using AutoMapper;
using Service.Model.Entity;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IMapper _mapper;
        private readonly IToDoRepositroy _toDoRepositroy;

        public ToDoService(IToDoRepositroy toDoRepositroy, IMapper mapper)
        {
            _mapper = mapper;
            _toDoRepositroy = toDoRepositroy;
        }

        public async Task Create(List<ToDoStateDto> toDoStateDtos, int OrderId)
        {
            var ToDos = _mapper.Map<List<ToDo>>(toDoStateDtos);

            foreach (var toDo in ToDos)
            {
                toDo.OrderId = OrderId;
                toDo.Id = 0;
            }

            await _toDoRepositroy.Create(ToDos);
        }
    }
}