using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetLastOrder
{
    public class GetLastOrderQueryHandler : IRequestHandler<GetLastOrderQuery, DisplayOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetLastOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<DisplayOrderDto> Handle(GetLastOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetLastOrder();
            var diplsyOrderDto = _mapper.Map<DisplayOrderDto>(order);

            return diplsyOrderDto;
        }
    }
}