using Service.ViewModel.Dtos;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public interface IFilter
    {
        IEnumerable<OrderDto> GetOrderDtos();
    }
}