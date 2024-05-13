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
    public class ToDoListCommand : CommandBase
    {
        private readonly ToDoListViewModel _toDoListViewModel;
        private readonly IOrderService _orderService;

        public ToDoListCommand(ToDoListViewModel toDoListViewModel, IOrderService orderService)
        {
            _toDoListViewModel = toDoListViewModel;
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