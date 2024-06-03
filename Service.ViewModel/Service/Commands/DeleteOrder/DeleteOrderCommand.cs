using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public string OrderName { get; }

        public DeleteOrderCommand(string orderName)
        {
            OrderName = orderName;
        }
    }
}