using Service.ViewModel.Dtos;
using Service.ViewModel.Stores;
using Servis.Models.OrderModels;

namespace Service.ViewModel.ViewModels.PrintOrderViewModels
{
    public class PrintViewModel : ViewModelBase
    {
        private OrderDto _orderDto;
        public Inprint inprint { get; }

        public PrintViewModel()
        {
            inprint = new Inprint("AD-KOMP Arkadius Dominiak",
             "ul. Szarych Szeregów 3", "Konin", "62-500", "534 078 017", "534 078 018", null);
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