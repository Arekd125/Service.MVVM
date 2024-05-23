using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Service.ViewModel.Commands.ToDoListCommand
{
    public class AddNewToDoCommand : CommandBase
    {
        private readonly IOrderService _orderService;
        private readonly ToDoStore _toDoStore;

        public AddNewToDoCommand(IOrderService orderService, ToDoStore toDoStore)
        {
            _orderService = orderService;
            _toDoStore = toDoStore;
        }

        public override void Execute(object? parameter)
        {
            ToDoStateDto toDo = parameter as ToDoStateDto;
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

                _toDoStore.AddTodo();
            }
        }
    }
}