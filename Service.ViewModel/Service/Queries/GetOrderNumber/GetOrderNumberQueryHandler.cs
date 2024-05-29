using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetOrderNumber
{
    public class GetOrderNumberQueryHandler : IRequestHandler<GetOrderNumberQuery, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderNumberQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(GetOrderNumberQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetLastOrder();
            if (order != null)
            {
                var lastOrderData = order.StartDate;

                if (lastOrderData.Month == DateTime.Now.Month && lastOrderData.Year == DateTime.Now.Year)
                {
                    return order.OrderNo + 1;
                }
            }

            return 1;
        }
    }
}