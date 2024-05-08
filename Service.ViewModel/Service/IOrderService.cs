using Service.ViewModel.Dtos;

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
    }
}