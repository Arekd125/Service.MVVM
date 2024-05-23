using Service.ViewModel.Dtos;
using System.Threading.Tasks;

namespace Service.ViewModel.Service
{
    public interface IOrderService
    {
        public Task<int> CreateOrder(CreateOrderDto orderDto, int contactId);

        public Task<IEnumerable<DisplayOrderDto>> GetAllOrders();

        public Task<DisplayOrderDto> GetLastOrder();

        public Task<int> GetOrderNumber();

        public Task<int> CreateContact(ContactDto contactDto);

        public Task<IEnumerable<ContactDto>> GetAllContacts();

        public Task<IEnumerable<ToDoStateDto>> GetAllToDos();

        public Task CreateToDoState(ToDoStateDto toDoDto);

        public Task UpdateToDoState(ToDoStateDto toDoDto);

        public Task DeleteToDoState(int id);
    }
}