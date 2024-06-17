using MediatR;
using Service.Model.Repositories;

namespace Service.ViewModel.Service.Queries.GetOrderNumber
{
    public class GetOrderNumberQueryHandler : IRequestHandler<GetOrderNumberQuery, int>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderNumberQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(GetOrderNumberQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetLastOrder();
            if (order != null)
            {
                var lastOrderData = order.StartDate;

                var isTheSameMonthAndYear = lastOrderData.Month == DateTime.Now.Month && lastOrderData.Year == DateTime.Now.Year;

                if (isTheSameMonthAndYear)
                {
                    return order.OrderNo + 1;
                }
            }

            return 1;
        }
    }
}