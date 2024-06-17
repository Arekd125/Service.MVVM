using MediatR;
using Service.Model.Repositories;

namespace Service.ViewModel.Service.Commands.EditOrderStatus
{
    public class EditOrderStatusCommandHandler : IRequestHandler<EditOrderStatusCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public EditOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(EditOrderStatusCommand request, CancellationToken cancellationToken)
        {


            _orderRepository.UpDateStatus(request.OrderName);

            return Unit.Value;
        }
    }
}
