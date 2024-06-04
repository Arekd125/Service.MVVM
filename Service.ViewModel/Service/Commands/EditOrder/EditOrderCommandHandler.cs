using AutoMapper;
using MediatR;
using Service.Model.Repositories;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Service.Commands.EditOrder
{
    internal class EditOrderCommandHandler : IRequestHandler<EditOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IContactRepository _contactRepository;

        public EditOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            

            var existingContact = await _contactRepository.GetContact(order);

            if (existingContact != null)
            {
                order.ContactId = existingContact.Id;
                order.Contact = null;
            }
            await _orderRepository.UpDate(order);

            return Unit.Value;
        }
    }
}
