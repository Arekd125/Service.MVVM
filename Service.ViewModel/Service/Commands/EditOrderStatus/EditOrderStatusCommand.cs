using MediatR;

namespace Service.ViewModel.Service.Commands.EditOrderStatus
{
    public class EditOrderStatusCommand : IRequest
    {

        public string OrderName { get; }
        public EditOrderStatusCommand(string orderName)
        {
            OrderName = orderName;
        }


    }
}
