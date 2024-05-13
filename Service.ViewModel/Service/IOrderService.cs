using Service.ViewModel.Dtos;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public interface IOrderService
    {
        public Task CreateOrder(CreateOrderDto orderDto, int contactId);

        public Task<IEnumerable<DisplayOrderDto>> GetAllOrders();

        public Task<DisplayOrderDto> GetLastOrder();

        public Task<int> GetOrderNumber();

        public Task<int> CreateContact(ContactDto contactDto);

        public Task<IEnumerable<ContactDto>> GetAllContacts();

        public Task<IEnumerable<ToDoDto>> GetAllToDos();

        public Task CreateToDoState(ToDoDto toDoDto);

        public Task UpdateToDoState(ToDoDto toDoDto);

        public Task DeleteToDoState(int id);
    }
}