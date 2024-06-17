using AutoMapper;
using MediatR;
using Service.Model.Repositories;

namespace Service.ViewModel.Service.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IContactRepository contactRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByOrderName(request.OrderName);

            if (order == null)
            {
                return Unit.Value;
            }

            var contactToDelet = order.Contact;

            await _orderRepository.Delete(order);

            var otherOrdersWithSameContact = await _orderRepository.AnyOrderWithContactId(contactToDelet.Id);

            if (!otherOrdersWithSameContact)
            {
                await _contactRepository.Delete(contactToDelet);
            }

            return Unit.Value;
        }
    }
}