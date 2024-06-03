using MediatR;
using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.DeleteOrder
{
    public class DeleteOrderCommand : OrderDto, IRequest
    {
     
        public DeleteOrderCommand(string orderName)
        {
            OrderName = orderName;
        }
    }
}