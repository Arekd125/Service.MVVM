using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service.Model.Entity;
using Service.Model.Repositories;
using Service.ViewModel.Dtos;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IContactRepository contactRepository, IToDoRepository toDoRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _contactRepository = contactRepository;
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task CreateOrder(CreateOrderDto createOrderDto, int ContacId)
        {
            var order = _mapper.Map<Order>(createOrderDto);

            order.ContactId = ContacId;

            await _orderRepository.Create(order);
        }

        public async Task<IEnumerable<DisplayOrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();

            var displayOrderDto = _mapper.Map<IEnumerable<DisplayOrderDto>>(orders);

            return displayOrderDto;
        }

        public async Task<DisplayOrderDto> GetLastOrder()
        {
            var order = await _orderRepository.GetLastOrder();
            var diplsyOrderDto = _mapper.Map<DisplayOrderDto>(order);

            return diplsyOrderDto;
        }

        public async Task<int> GetOrderNumber()
        {
            var order = await _orderRepository.GetLastOrder();
            if (order != null)
            {
                var lastOrderData = order.StartDate;

                if (lastOrderData.Month == DateTime.Now.Month && lastOrderData.Year == DateTime.Now.Year)
                {
                    return order.OrderNo + 1;
                }
            }

            return 1;
        }

        public async Task<int> CreateContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);

            return await _contactRepository.Create(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();

            var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return contactsDto;
        }

        public async Task<IEnumerable<ToDoStatsDto>> GetAllToDos()
        {
            var toDoState = await _toDoRepository.GetAllToDos();

            var toDoDto = _mapper.Map<IEnumerable<ToDoStatsDto>>(toDoState);

            return toDoDto;
        }

        public async Task CreateToDoState(ToDoStatsDto toDoDto)
        {
            var toDoState = _mapper.Map<ToDoState>(toDoDto);

            await _toDoRepository.Create(toDoState);
        }

        public async Task UpdateToDoState(ToDoStatsDto toDoDto)
        {
            var toDoState = _mapper.Map<ToDoState>(toDoDto);

            await _toDoRepository.UpDate(toDoState);
        }

        public async Task DeleteToDoState(int id)
        {
            await _toDoRepository.Remove(id);
        }
    }
}