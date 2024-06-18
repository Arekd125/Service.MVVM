using Service.ViewModel.Dtos;

namespace Service.ViewModel.Stores
{
    public class OrderStore
    {
        public event Action<OrderDto> OrderCreated;

        public void AddLastOrder(OrderDto orderDto)
        {
            OrderCreated?.Invoke(orderDto);
        }

        public event Action<OrderDto> OrderSentToEdit;

        public void OrderToEdit(OrderDto orderName)
        {
            OrderSentToEdit?.Invoke(orderName);
        }

        public event Action<OrderDto> OrderEdited;

        public void OrderChanged(OrderDto orderDto)
        {
            OrderEdited?.Invoke(orderDto);
        }

        public event Action FiltringChanged;

        public void RefreshOrders()
        {
            FiltringChanged?.Invoke();
        }

        public event Action ChangeFiltrOrders;

        public void SetFiltrAllOrders()
        {
            ChangeFiltrOrders?.Invoke();
        }
    }
}