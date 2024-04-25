using AutoMapper;
using Service.Model.Interfaces;
using Service.ViewModel.Dtos;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);

            await _orderRepository.Create(order);
        }

        public async Task<IEnumerable<DisplayOrderDto>> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders().Result;

            var displayOrderDto = _mapper.Map<IEnumerable<DisplayOrderDto>>(orders);

            return displayOrderDto;
        }

        public async Task<DisplayOrderDto> GetLastOrder()
        {
            var order = _orderRepository.GetLastOrder().Result;
            var diplsyOrderDto = _mapper.Map<DisplayOrderDto>(order);

            return diplsyOrderDto;
        }

        public async Task<int> GetOrderNumber()
        {
            var order = _orderRepository.GetLastOrder().Result;
            var lastOrderData = order.StartDate;

            if (lastOrderData.Month == DateTime.Now.Month)
            {
                return order.OrderNo + 1;
            }

            return 1;
        }
    }
}