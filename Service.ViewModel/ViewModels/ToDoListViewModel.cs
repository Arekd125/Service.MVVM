﻿using AutoMapper;
using MediatR;
using Service.ViewModel.Commands.ToDoListCommand;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetAllToDoState;
using Service.ViewModel.Stores;
using System.Collections.ObjectModel;
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

        public ToDoListViewModel(IMediator mediator, IMapper mapper, ToDoStore toDoStore)
        {
            _mediator = mediator;
            _toDoItemSource = new ObservableCollection<ToDoStateDto>();
            AddNewToDoCommand = new AddNewToDoCommand(mediator, mapper, toDoStore);
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