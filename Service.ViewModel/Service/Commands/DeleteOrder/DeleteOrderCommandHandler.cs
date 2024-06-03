using MediatR;
using Service.Model.Repositories;
using Service.ViewModel.Service.Commands.DeleteToDoState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IContactRepository _contactRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IContactRepository contactRepository)
        {
            _orderRepository = orderRepository;
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var Order = await _orderRepository.GetOrderByOrderName(request.OrderName);

            if (Order == null)
            {
                return Unit.Value;
            }

            var contactToDelet = Order.Contact;

            await _orderRepository.Delete(Order);

            var otherOrdersWithSameContact = await _orderRepository.AnyOrderWithContactId(contactToDelet.Id);

            if (!otherOrdersWithSameContact)
            {
                await _contactRepository.Delete(contactToDelet);
            }

            return Unit.Value;
        }
    }
}