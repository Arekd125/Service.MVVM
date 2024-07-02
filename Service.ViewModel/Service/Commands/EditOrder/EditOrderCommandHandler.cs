using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Service.Commands.EditOrder
{
    internal class EditOrderCommandHandler : IRequestHandler<EditOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IToDoRepository _todoRepository;

        public EditOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IContactRepository contactRepository, IToDoRepository todoRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _contactRepository = contactRepository;
            _todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var NewOrder = _mapper.Map<Order>(request);
            var OldOrder = await _orderRepository.GetOrderByOrderName(request.OrderName);

            var contactToDelet = OldOrder.Contact;

            var existingContact = await _contactRepository.GetContact(NewOrder);

            if (existingContact != null)
            {
                NewOrder.ContactId = existingContact.Id;
                NewOrder.Contact = null;
            }

            NewOrder.StartDate = DateTime.Now;

            await _todoRepository.Remove(NewOrder.Id);
            await _orderRepository.UpDate(NewOrder);

            var otherOrdersWithSameContact = await _orderRepository.AnyOrderWithContactId(contactToDelet.Id);

            if (!otherOrdersWithSameContact)
            {
                contactToDelet.Order = null;
                await _contactRepository.Delete(contactToDelet);
            }

            return Unit.Value;
        }
    }
}