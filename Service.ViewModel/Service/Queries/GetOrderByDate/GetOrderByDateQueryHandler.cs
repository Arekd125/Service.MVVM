using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;

namespace Service.ViewModel.Service.Queries.GetOrderByDate
{
    public class GetOrderByDateQueryHandler : IRequestHandler<GetOrderByDateQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByDateQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrderByDateQuery request, CancellationToken cancellationToken)
        {
            var Orders = await _orderRepository.GetOrdersByDate(request.StartDate, request.EndDate);

            var OrdersDto = _mapper.Map<IEnumerable<OrderDto>>(Orders);

            return OrdersDto;
        }
    }
}