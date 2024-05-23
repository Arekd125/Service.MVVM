using Service.Model.Entity;
using Service.ViewModel.Commands.ToDoListCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Stores;
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
        private ObservableCollection<ToDoStateDto> _toDoItemSource;
        private readonly IOrderService _orderService;

        public IEnumerable<ToDoStateDto> ToDoItemSource => _toDoItemSource;

        public ICommand AddNewToDoCommand { get; set; }
        public ICommand DeleteToDoCommand { get; set; }

        public ToDoListViewModel(IOrderService orderService, ToDoStore toDoStore)
        {
            _orderService = orderService;
            _toDoItemSource = new ObservableCollection<ToDoStateDto>();
            AddNewToDoCommand = new AddNewToDoCommand(orderService, toDoStore);
            DeleteToDoCommand = new DeleteToDoCommand(orderService, toDoStore);
            AllToDos();
        }

        public void Add(ToDoStateDto toDoDto)
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