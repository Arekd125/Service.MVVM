using Service.ViewModel.Dtos;
using Service.ViewModel.Stores;
using Servis.Models.OrderModels;

namespace Service.ViewModel.ViewModels.PrintOrderViewModels
{
    public class PrintViewModel : ViewModelBase
    {
        private OrderDto _orderDto;
        public Inprint inprint { get; }
        public string rodo { get; }

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

        public PrintViewModel()
        {
            inprint = new Inprint("AD-KOMP Arkadius Dominiak",
             "Szarych Szeregów 3", "Konin", "62-500", "534 078 017", "534 078 018", null);

            rodo = @$"W związku z realizacją niniejszego zlecenia, informujemy,że w celu jego wykonania niezbędne jest przetwarzanie Państwa danych osobowych.
Administratorem danych osobowych jest {inprint.Name} z siedzibą w {inprint.City}ie {inprint.Street}.
Ja, niżej podpisany/a, wyrażam zgodę na przetwarzanie moich danych osobowych przez {inprint.Name} z siedzibą w {inprint.City}ie w celu realizacji zlecenia.";
        }

        private void ToDoSpliter()
        {
            _todo2 = new List<ToDoDto>();
            if (Order.ToDo.Count() > 5)
            {
                ToDo2 = _orderDto.ToDo.Skip(5).ToList();
                Order.ToDo = _orderDto.ToDo.Take(5).ToList();
            }
        }
    }
}