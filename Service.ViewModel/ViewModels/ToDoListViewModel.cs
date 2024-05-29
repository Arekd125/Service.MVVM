using MediatR;
using Service.Model.Entity;
using Service.ViewModel.Commands.ToDoListCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Queries.GetAllToDoState;
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
        private readonly IMediator _mediator;

        public IEnumerable<ToDoStateDto> ToDoItemSource => _toDoItemSource;

        public ICommand AddNewToDoCommand { get; set; }
        public ICommand DeleteToDoCommand { get; set; }

        public ToDoListViewModel(IMediator mediator, ToDoStore toDoStore)
        {
            _mediator = mediator;
            _toDoItemSource = new ObservableCollection<ToDoStateDto>();
            AddNewToDoCommand = new AddNewToDoCommand(mediator, toDoStore);
            DeleteToDoCommand = new DeleteToDoCommand(mediator, toDoStore);
            AllToDos();
        }

        public void Add(ToDoStateDto toDoDto)
        {
            _toDoItemSource.Add(toDoDto);
        }

        private void AllToDos()
        {
            var getAllToDos = _mediator.Send(new GetAllToDoStateQuery()).Result;

            foreach (var o in getAllToDos)
            {
                Add(o);
            }
        }
    }
}