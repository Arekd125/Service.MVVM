using Service.ViewModel.Dtos;

namespace Service.ViewModel.ViewModels.PrintOrderViewModels
{
    public class PrintViewModel : ViewModelBase
    {
        private OrderDto _orderDto;
        public Inprint inprint { get; }
        public string rodo { get; set; }

        public OrderDto Order
        {
            get
            {
                return _orderDto;
            }
            set
            {
                _orderDto = value;
                OnPropertyChanged(nameof(Order));
                ToDoSpliter();
            }
        }

        private IEnumerable<ToDoDto> _todo1;

        public IEnumerable<ToDoDto> ToDo1
        {
            get
            {
                return _todo1;
            }
            set
            {
                _todo1 = value;
                OnPropertyChanged(nameof(ToDo1));
            }
        }

        private IEnumerable<ToDoDto> _todo2;

        public IEnumerable<ToDoDto> ToDo2
        {
            get
            {
                return _todo2;
            }
            set
            {
                _todo2 = value;
                OnPropertyChanged(nameof(ToDo2));
            }
        }

        public PrintViewModel(Inprint inprint)
        {
            this.inprint = inprint;
            SetRodo();
        }

        private void SetRodo()
        {
            rodo = @$"W związku z realizacją niniejszego zlecenia, informujemy,że w celu jego wykonania niezbędne jest przetwarzanie Państwa danych osobowych.
Administratorem danych osobowych jest {inprint.Name} z siedzibą w {inprint.City} {inprint.Street}.
Ja, niżej podpisany/a, wyrażam zgodę na przetwarzanie moich danych osobowych przez {inprint.Name} z siedzibą w {inprint.City} w celu realizacji zlecenia.";
        }

        private void ToDoSpliter()
        {
            _todo2 = new List<ToDoDto>();
            if (Order.ToDo.Count() > 5)
            {
                ToDo1 = _orderDto.ToDo.Take(5).ToList();
                ToDo2 = _orderDto.ToDo.Skip(5).ToList();
            }
            else
            {
                ToDo1 = _orderDto.ToDo;
            }
        }
    }
}