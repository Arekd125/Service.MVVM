using Service.ViewModel.Dtos;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Service
{
    public interface IOrderService
    {
        public Task Create(CreateOrderDto orderDto);

        public Task<IEnumerable<DisplayOrderDto>> GetAllOrders();

        public Task<DisplayOrderDto> GetLastOrder();

        public Task<int> GetOrderNumber();
    }
}