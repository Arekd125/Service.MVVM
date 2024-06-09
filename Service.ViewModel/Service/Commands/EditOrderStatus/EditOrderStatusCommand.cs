using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.EditOrderStatus
{
    public class EditOrderStatusCommand : IRequest
    {
      
        public string OrderName { get; }
        public EditOrderStatusCommand( string orderName)
        {
            OrderName = orderName;
        }


    }
}
