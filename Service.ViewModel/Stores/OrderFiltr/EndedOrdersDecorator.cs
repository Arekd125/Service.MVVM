using Service.ViewModel.Dtos;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public class EndedOrdersDecorator : FiltrDecorator
    {
        public EndedOrdersDecorator(IFilter filter) : base(filter)
        {
        }

        public override IEnumerable<OrderDto> GetOrderDtos()
        {
            return base.GetOrderDtos().Where(o => o.IsFinished == true);
        }
    }
}