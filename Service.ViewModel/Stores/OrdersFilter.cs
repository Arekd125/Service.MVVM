using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Stores.Converstes;
using Service.ViewModel.Stores.OrderFiltr;

namespace Service.ViewModel.Stores
{
    public class OrdersFilter
    {
        private readonly IMediator _mediator;
        private readonly OrderStore _orderStore;

        public int SelectedFiltrBuffor { get; set; } = 0;
        private string? SerchTextBuffor { get; set; }
        public IFilter StatusFilter { get; set; }
        public IFilter DateFiler { get; set; }
        public IFilter SeachFilter { get; set; }

        public OrdersFilter(IMediator mediator, OrderStore orderStore)
        {
            _mediator = mediator;
            _orderStore = orderStore;
            SelectDateFilter(DateFilerEnum.month);
        }

        public IEnumerable<OrderDto> SendOrderDtos() => SeachFilter.GetOrderDtos();

        public void SelectDateFilter(DateFilerEnum dateFilerEnum)
        {
            switch (dateFilerEnum)
            {
                case DateFilerEnum.today:
                    DateFiler = new TodayOrdersFiilter(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.yesterday:
                    DateFiler = new YesterdayOrdersFilter(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.week:
                    DateFiler = new LastWeekOrdersFilter(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.month:
                    DateFiler = new LastMonth(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.from_the_beginning:
                    DateFiler = new FromTheBeginingOrdersFilter(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                default:
                    break;
            }
        }

        public void SelectFiltr(int filtr)
        {
            if (filtr == 0)
            {
                StatusFilter = new OpenOrdersDecorator(DateFiler);
                Search(SerchTextBuffor);
            }
            if (filtr == 1)
            {
                StatusFilter = new EndedOrdersDecorator(DateFiler);
                Search(SerchTextBuffor);
            }
            if (filtr == 2)
            {
                StatusFilter = new AllOrdersDecorator(DateFiler);
                Search(SerchTextBuffor);
            }
            SelectedFiltrBuffor = filtr;
        }

        public void Search(string text)
        {
            SeachFilter = new SearchOrdersDecorator(StatusFilter, text);
            _orderStore.RefreshOrders();
            SerchTextBuffor = text;
        }
    }
}