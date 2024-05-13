using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.ToDoListCommand
{
    public class AddNewToDoCommand : CommandBase
    {
        private readonly IOrderService _orderService;

        public AddNewToDoCommand(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public override void Execute(object? parameter)
        {
            ToDoDto toDo = parameter as ToDoDto;
            if (toDo != null)
            {
                if (toDo.Id == 0)
                {
                    _orderService.CreateToDoState(toDo);
                }
                else
                {
                    _orderService.UpdateToDoState(toDo);
                }
            }
        }
    }
}