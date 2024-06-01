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