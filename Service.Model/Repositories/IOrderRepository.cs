using Servis.Models.OrderModels;

namespace Service.Model.Repositories
{
    public interface IOrderRepository
    {
        public Task Create(Order order);

        public Task<IEnumerable<Order>> GetAllOrders();

        public Task<Order?> GetLastOrder();

        public Task<Order?> GetOrderByOrderName(string OrderName);

        public Task Delete(Order order);

        public Task<bool> AnyOrderWithContactId(int contactId);

        public Task UpDate(Order order);

        public Task UpDateStatus(string orderName);

        public Task<IEnumerable<Order>> GetOrdersByDate(DateTime startDate, DateTime endDate);

        public Task<int> GetNumberOpenedOrders();
    }
}