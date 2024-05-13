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
        private ObservableCollection<ToDoDto> _toDoItemSource;
        private readonly IOrderService _orderService;

        public IEnumerable<ToDoDto> ToDoItemSource => _toDoItemSource;

        public ICommand ToDoListCommand { get; set; }

        public ToDoListViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            _toDoItemSource = new ObservableCollection<ToDoDto>();
            ToDoListCommand = new ToDoListCommand(this, orderService);
            AllToDos();
        }

        public void Add(ToDoDto toDoDto)
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