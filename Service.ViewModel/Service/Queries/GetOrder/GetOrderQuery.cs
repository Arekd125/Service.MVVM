using MediatR;
using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public string OrderName { get; }

        public GetOrderQuery(string orderName)
        {
            OrderName = orderName;
        }
    }
}