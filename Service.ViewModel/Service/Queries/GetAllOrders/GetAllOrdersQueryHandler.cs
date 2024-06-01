﻿using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetAllDeviceName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<DisplayOrderDto>>

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DisplayOrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();

            var displayOrderDto = _mapper.Map<IEnumerable<DisplayOrderDto>>(orders);

            return displayOrderDto;
        }
    }
}