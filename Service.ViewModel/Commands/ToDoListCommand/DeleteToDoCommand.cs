using Service.Model.Entity;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.ToDoListCommand
{
    public class DeleteToDoCommand : CommandBase
    {
        private readonly ToDoStore _toDoStore;
        private readonly IOrderService _orderService;

        public DeleteToDoCommand(IOrderService orderService, ToDoStore toDoStore)
        {
            _orderService = orderService;
            _toDoStore = toDoStore;
        }

        public override void Execute(object? parameter)
        {
            ToDoStateDto toDoDto = (ToDoStateDto)parameter;
            _orderService.DeleteToDoState(toDoDto.Id);
            _toDoStore.DeleteTodo();
        }
    }
}