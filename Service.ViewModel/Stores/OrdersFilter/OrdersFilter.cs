using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Stores.Converstes;
using Service.ViewModel.Stores.OrderFiltr;
using Service.ViewModel.Stores.OrderFiltr.DateFilter;
using Service.ViewModel.Stores.OrderFiltr.SearchFilter;
using Service.ViewModel.Stores.OrderFiltr.StatusFilter;

namespace Service.ViewModel.Stores.OrdersFilter
{
    public class OrdersFilter
    {
        private readonly IMediator _mediator;
        private readonly OrderStore _orderStore;
        private readonly DateFilterFactrory _dateFilterFactrory;

        public int SelectedFiltrBuffor { get; set; } = 0;
        private string? SerchTextBuffor { get; set; }
        public IFilter StatusFilter { get; set; }
        public IFilter DateFilter { get; set; }
        public IFilter SeachFilter { get; set; }

        public OrdersFilter(IMediator mediator, OrderStore orderStore, DateFilterFactrory dateFilterFactrory)
        {
            _mediator = mediator;
            _orderStore = orderStore;
            _dateFilterFactrory = dateFilterFactrory;
            SelectDateFilter(DateFilerEnum.month);
        }

        public IEnumerable<OrderDto> SendOrderDtos() => SeachFilter.GetOrderDtos();

        public void SelectDateFilter(DateFilerEnum dateFilerEnum)
        {
            DateFilter = _dateFilterFactrory.CreateFilter(dateFilerEnum);
            SelectFiltr(SelectedFiltrBuffor);
        }

        public void SelectFiltr(int filtr)
        {
            if (filtr == 0)
            {
                StatusFilter = new OpenOrdersDecorator(DateFilter);
                Search(SerchTextBuffor);
            }
            if (filtr == 1)
            {
                StatusFilter = new EndedOrdersDecorator(DateFilter);
                Search(SerchTextBuffor);
            }
            if (filtr == 2)
            {
                StatusFilter = new AllOrdersDecorator(DateFilter);
                Search(SerchTextBuffor);
            }
            SelectedFiltrBuffor = filtr;
        }

        public void Search(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SeachFilter = new SearchOrderDecorator(StatusFilter, text);
            }
            else
            {
                SeachFilter = StatusFilter;
            }

            _orderStore.RefreshOrders();
            SerchTextBuffor = text;
        }
    }
}