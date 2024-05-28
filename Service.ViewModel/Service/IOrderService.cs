﻿using Service.ViewModel.Dtos;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public interface IOrderService
    {
        public Task CreateOrder(CreateOrderDto orderDto);

        public Task<IEnumerable<DisplayOrderDto>> GetAllOrders();

        public Task<DisplayOrderDto?> GetLastOrder();

        public Task<int> GetOrderNumber();

        public Task<IEnumerable<ContactDto>> GetAllContacts();

        public Task<IEnumerable<ToDoStateDto>> GetAllToDoState();

        public Task<IEnumerable<ToDoDto>> GetAllToDo();

        public Task CreateToDoState(ToDoStateDto toDoDto);

        public Task UpdateToDoState(ToDoStateDto toDoDto);

        public Task DeleteToDoState(int id);
    }
}