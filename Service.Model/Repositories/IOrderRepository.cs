using Servis.Models.OrderModels;

namespace Service.Model.Repositories
{
    public interface IOrderRepository
    {
        public Task Create(Order order);

        public Task<IEnumerable<Order>> GetAllOrders();

        public Task<Order?> GetLastOrder();
    }
}