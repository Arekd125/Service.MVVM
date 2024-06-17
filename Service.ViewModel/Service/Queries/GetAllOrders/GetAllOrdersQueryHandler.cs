using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();

            var displayOrderDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return displayOrderDto;
        }
    }
}