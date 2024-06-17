using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetAllToDo;
using Service.ViewModel.Stores;
using System.Collections.ObjectModel;

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

        private int _selectedIndex = -1;

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
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
            set
            {
                _toDoSelectedItems = value;
                OnPropertyChanged(nameof(ToDoItemSource));
            }
        }

        private string _accessories = string.Empty;

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

        private readonly IMediator _mediator;
        private readonly ToDoStore _toDoStore;

        public DescriptionViewModel(IMediator mediator, ToDoStore toDoStore)
        {
            _toDoStore = toDoStore;
            _mediator = mediator;
            ToDoItemSource = _mediator.Send(new GetAllToDoQuery()).Result;
            _toDoStore.ToDoAction += OnToDoAction;
            _toDoSelectedItems = new ObservableCollection<ToDoDto>();
        }

        public void SetToDoItems(IEnumerable<ToDoDto> items)
        {
            var list2 = _mediator.Send(new GetAllToDoQuery()).Result.ToList();

            ToDoItemSource = items.Union(list2, new ToDoComparer());

            foreach (var item in items)
            {
                ToDoSelectedItems.Add(item);
            }
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

        public void Clear()
        {
            DescriptionTextBox = string.Empty;
            AccessoriesTexBox = string.Empty;
            SelectedIndex = -1;
            ToDoItemSource = _mediator.Send(new GetAllToDoQuery()).Result;
            ToDoSelectedItems.Clear();
        }
    }
}