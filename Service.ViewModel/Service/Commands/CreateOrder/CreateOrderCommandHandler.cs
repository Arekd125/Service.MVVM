using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Service.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IContactRepository contactRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);

            var existingContact = await _contactRepository.GetContact(order);

            if (existingContact != null)
            {
                order.ContactId = existingContact.Id;
                order.Contact = null;
            }

            await _orderRepository.Create(order);

            return Unit.Value;
        }
    }
}