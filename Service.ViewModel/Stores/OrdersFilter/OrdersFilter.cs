using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Stores.Converstes;
using Service.ViewModel.Stores.OrderFiltr;
using Service.ViewModel.Stores.OrderFiltr.DateFilter;
using Service.ViewModel.Stores.OrderFiltr.SearchFilter;
using Service.ViewModel.Stores.OrderFiltr.StatusFilter;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service.ViewModel.Stores.OrdersFilter
{
    public class OrdersFilter
    {
        private readonly IMediator _mediator;
        private readonly OrderStore _orderStore;

        public int SelectedFiltrBuffor { get; set; } = 0;
        private string? SerchTextBuffor { get; set; }
        public IFilter StatusFilter { get; set; }
        public IFilter DateFilter { get; set; }
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
                    DateFilter = new TodayOrdersFiilter(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.yesterday:
                    DateFilter = new YesterdayOrdersFilter(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.week:
                    DateFilter = new LastWeekOrdersFilter(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.month:
                    DateFilter = new LastMonth(_mediator);
                    SelectFiltr(SelectedFiltrBuffor);
                    break;

                case DateFilerEnum.from_the_beginning:
                    DateFilter = new FromTheBeginingOrdersFilter(_mediator);
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