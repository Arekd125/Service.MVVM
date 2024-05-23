using Service.Model.Entity;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
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

        private IEnumerable<ToDoStateDto> _toDoItemSource;

        public IEnumerable<ToDoStateDto> ToDoItemSource
        {
            get
            {
                if (_toDoItemSource == null)
                    _toDoItemSource = _orderService.GetAllToDos().Result;
                return _toDoItemSource;
            }
            set
            {
                _toDoItemSource = value;
                OnPropertyChanged(nameof(ToDoItemSource));
            }
        }

        private ObservableCollection<ToDoStateDto> _toDoSelectedItems;

        public ObservableCollection<ToDoStateDto> ToDoSelectedItems
        {
            get
            {
                return _toDoSelectedItems;
            }
        }

        private string _accessories = string.Empty;
        private readonly IOrderService _orderService;
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

        public DescriptionViewModel(IOrderService orderService, ToDoStore toDoStore)
        {
            _orderService = orderService;
            _toDoStore = toDoStore;
            _toDoStore.ToDoAction += OnToDoAction;
            _toDoSelectedItems = new ObservableCollection<ToDoStateDto>();
        }

        private void OnToDoAction()
        {
            ToDoItemSource = _orderService.GetAllToDos().Result;
        }
    }
}