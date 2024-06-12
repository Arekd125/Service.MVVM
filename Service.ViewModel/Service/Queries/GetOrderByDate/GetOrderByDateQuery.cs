using MediatR;
using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Queries.GetOrderByDate
{
    public class GetOrderByDateQuery : IRequest<IEnumerable<OrderDto>>
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public GetOrderByDateQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}