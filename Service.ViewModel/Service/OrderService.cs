using AutoMapper;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using Servis.Models.OrderModels;

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

        public async Task CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);

            await _orderRepository.Create(order);
        }

        public async Task<IEnumerable<DisplayOrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();

            var displayOrderDto = _mapper.Map<IEnumerable<DisplayOrderDto>>(orders);

            return displayOrderDto;
        }

        public async Task<DisplayOrderDto> GetLastOrder()
        {
            var order = await _orderRepository.GetLastOrder();
            var diplsyOrderDto = _mapper.Map<DisplayOrderDto>(order);

            return diplsyOrderDto;
        }

        public async Task<int> GetOrderNumber()
        {


            var order = await _orderRepository.GetLastOrder();
            if (order != null)
            {
                var lastOrderData = order.StartDate;

                if (lastOrderData.Month == DateTime.Now.Month && lastOrderData.Year == DateTime.Now.Year )
                {
                    return order.OrderNo + 1;
                }
            }

            return 1;
        }
    }
}