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

        public PrintViewModel()
        {
            inprint = new Inprint("AD-KOMP Arkadius Dominiak",
             "Szarych Szeregów 3", "Konin", "62-500", "534 078 017", "534 078 018", null);

            rodo = @$"W związku z realizacją niniejszego zlecenia, informujemy,że w celu jego wykonania niezbędne jest przetwarzanie Państwa danych osobowych.
Administratorem danych osobowych jest {inprint.Name} z siedzibą w {inprint.City}ie {inprint.Street}.
Ja, niżej podpisany/a, wyrażam zgodę na przetwarzanie moich danych osobowych przez {inprint.Name} z siedzibą w {inprint.City}ie w celu realizacji zlecenia.";
        }

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
            }
        }
    }
}