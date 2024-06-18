using Service.ViewModel.Dtos;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public abstract class FiltrDecorator : IFilter
    {
        private IFilter _filter;

        protected FiltrDecorator(IFilter filter)
        {
            _filter = filter;
        }

        public virtual IEnumerable<OrderDto> GetOrderDtos()
        {
            return _filter.GetOrderDtos();
        }
    }
}