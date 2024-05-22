using Service.Model.Entity;
using Service.ViewModel.Commands.ToDoListCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        private ObservableCollection<ToDoStatsDto> _toDoItemSource;
        private readonly IOrderService _orderService;

        public IEnumerable<ToDoStatsDto> ToDoItemSource => _toDoItemSource;

        public ICommand AddNewToDoCommand { get; set; }
        public ICommand DeleteToDoCommand { get; set; }

        public ToDoListViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            _toDoItemSource = new ObservableCollection<ToDoStatsDto>();
            AddNewToDoCommand = new AddNewToDoCommand(orderService);
            DeleteToDoCommand = new DeleteToDoCommand(orderService);
            AllToDos();
        }

        public void Add(ToDoStatsDto toDoDto)
        {
            _toDoItemSource.Add(toDoDto);
        }

        private void AllToDos()
        {
            var getAllToDos = _orderService.GetAllToDos().Result;

            foreach (var o in getAllToDos)
            {
                Add(o);
            }
        }
    }
}