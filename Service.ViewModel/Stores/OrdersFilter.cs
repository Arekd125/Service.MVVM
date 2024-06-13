using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Stores.OrderFiltr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores
{
    public class OrdersFilter
    {
        private readonly IMediator _mediator;
        private readonly OrderStore _orderStore;

        public IFilter StatusFilter { get; set; }
        public IFilter DateFiler { get; set; }

        public OrdersFilter(IMediator mediator, OrderStore orderStore)
        {
            _mediator = mediator;
            _orderStore = orderStore;
            DateFiler = new TodayOrdersFiltr(_mediator);
            StatusFilter = new OpenOrdersDecorator(DateFiler);
        }

        public IEnumerable<OrderDto> SendtOrderDtos()
        {
            return StatusFilter.GetOrderDtos();
        }

        public void SelectFiltr(int filtr)
        {
            if (filtr == 0)
            {
                StatusFilter = new OpenOrdersDecorator(DateFiler);
                _orderStore.RefreshOrders();
            }
            if (filtr == 1)
            {
                StatusFilter = new EndedOrdersDecorator(DateFiler);
                _orderStore.RefreshOrders();
            }
            if (filtr == 2)
            {
                StatusFilter = new AllOrdersDecorator(DateFiler);
                _orderStore.RefreshOrders();
            }
        }
    }
}