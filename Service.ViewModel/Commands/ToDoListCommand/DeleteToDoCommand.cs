using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.ToDoListCommand
{
    public class DeleteToDoCommand : CommandBase
    {
        private readonly IOrderService _orderService;

        public DeleteToDoCommand(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public override void Execute(object? parameter)
        {
            ToDoDto toDoDto = (ToDoDto)parameter;
            _orderService.DeleteToDoState(toDoDto.Id);
        }
    }
}