using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByOrderName(request.OrderName);
            return _mapper.Map<OrderDto>(order);
        }
    }
}