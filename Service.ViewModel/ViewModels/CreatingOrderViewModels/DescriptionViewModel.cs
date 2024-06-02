using MediatR;
using Service.Model.Entity;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Queries.GetAllToDo;
using Service.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class DescriptionViewModel : ViewModelBase
    {
        private string _description = string.Empty;

        public string DescriptionTextBox
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(DescriptionTextBox));
            }
        }

        private string _toDo = string.Empty;

        public string ToDoTextBox
        {
            get
            {
                return _toDo;
            }
            set
            {
                _toDo = value;
                OnPropertyChanged(nameof(ToDoTextBox));
            }
        }

        private IEnumerable<ToDoDto>? _toDoItemSource;

        public IEnumerable<ToDoDto>? ToDoItemSource
        {
            get
            {           
                return _toDoItemSource;
            }
            set
            {
                _toDoItemSource = value;
                OnPropertyChanged(nameof(ToDoItemSource));
            }
        }

        private ObservableCollection<ToDoDto> _toDoSelectedItems;

        public ObservableCollection<ToDoDto> ToDoSelectedItems
        {
            get
            {
                return _toDoSelectedItems;
            }
        }

        private string _accessories = string.Empty;
        private readonly IMediator _mediator;
        private readonly ToDoStore _toDoStore;

        public string AccessoriesTexBox
        {
            get
            {
                return _accessories;
            }
            set
            {
                _accessories = value;
                OnPropertyChanged(nameof(AccessoriesTexBox));
            }
        }

        public DescriptionViewModel(IMediator mediator, ToDoStore toDoStore)
        {
            _toDoStore = toDoStore;
            _mediator = mediator;
            ToDoItemSource = _mediator.Send(new GetAllToDoQuery()).Result;
            _toDoStore.ToDoAction += OnToDoAction;
            _toDoSelectedItems = new ObservableCollection<ToDoDto>();
            
        }

        private void OnToDoAction()
        {
            ToDoItemSource = _mediator.Send(new GetAllToDoQuery()).Result;
        }

        public override void Dispose()
        {
            _toDoStore.ToDoAction -= OnToDoAction;
            base.Dispose();
        }
    }
}