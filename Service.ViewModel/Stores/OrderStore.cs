using Service.ViewModel.Dtos;

namespace Service.ViewModel.Stores
{
    public class OrderStore
    {
        public event Action<OrderDto> OrderCreated;

        public event Action<OrderDto> OrderSentToEdit;

        public event Action<OrderDto> OrderEdited;

        public event Action FiltringChanged;

        public event Action ChangeFiltrOrders;

        public void AddLastOrder(OrderDto orderDto)
        {
            OrderCreated?.Invoke(orderDto);
        }

        public void OrderToEdit(OrderDto orderName)
        {
            OrderSentToEdit?.Invoke(orderName);
        }

        public void OrderChanged(OrderDto orderDto)
        {
            OrderEdited?.Invoke(orderDto);
        }

        public void RefreshOrders()
        {
            FiltringChanged?.Invoke();
        }

        public void SetFiltrAllOrders()
        {
            ChangeFiltrOrders?.Invoke();
        }
    }
}