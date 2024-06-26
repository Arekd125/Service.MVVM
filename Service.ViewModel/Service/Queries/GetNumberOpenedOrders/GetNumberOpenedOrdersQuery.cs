using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetNumberOpenedOrders
{
    public class GetNumberOpenedOrdersQuery : IRequest<int>
    {
    }
}