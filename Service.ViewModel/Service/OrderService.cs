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
        private readonly IToDoStateRepository _toDoRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IContactRepository contactRepository, IToDoStateRepository toDoRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _contactRepository = contactRepository;
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public async Task CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);

            await _orderRepository.Create(order);
        }

        public async Task<IEnumerable<DisplayOrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();

            var displayOrderDto = _mapper.Map<IEnumerable<DisplayOrderDto>>(orders);

            return displayOrderDto;
        }

        public async Task<DisplayOrderDto?> GetLastOrder()
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

        public async Task<IEnumerable<ContactDto>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();

            var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return contactsDto;
        }

        public async Task<IEnumerable<ToDoStateDto>> GetAllToDos()
        {
            var toDoState = await _toDoRepository.GetAllToDos();

            var toDoDto = _mapper.Map<IEnumerable<ToDoStateDto>>(toDoState);

            return toDoDto;
        }

        public async Task CreateToDoState(ToDoStateDto toDoDto)
        {
            var toDoState = _mapper.Map<ToDoState>(toDoDto);

            await _toDoRepository.Create(toDoState);
        }

        public async Task UpdateToDoState(ToDoStateDto toDoDto)
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