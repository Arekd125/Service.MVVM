using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
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

        private IEnumerable<string> _toDoItemSource;

        public IEnumerable<string> ToDoItemSource
        {
            get
            {
                _toDoItemSource = _orderService.GetAllToDos().Result.Select(p => p.ToDoName);
                return _toDoItemSource;
            }
            set
            {
                _toDoItemSource = value;
                OnPropertyChanged(nameof(ToDoItemSource));
            }
        }

        private string _accessories = string.Empty;
        private readonly IOrderService _orderService;

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

        public DescriptionViewModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}