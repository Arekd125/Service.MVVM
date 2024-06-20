using MediatR;
using Service.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetNumberOpenedOrders
{
    public class GetNumberOpenedOrdersQueryHandler : IRequestHandler<GetNumberOpenedOrdersQuery, int>
    {
        private readonly IOrderRepository _orderRepository;

        public GetNumberOpenedOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(GetNumberOpenedOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetNumberOpenedOrders();
        }
    }
}