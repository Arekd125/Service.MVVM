using Service.ViewModel.Dtos;

namespace Service.ViewModel.Stores.OrderFiltr.StatusFilter
{
    public class OpenOrdersDecorator : FiltrDecorator
    {
        public OpenOrdersDecorator(IFilter filter) : base(filter)
        {
        }

        public override IEnumerable<OrderDto> GetOrderDtos()
        {
            return base.GetOrderDtos().Where(o => o.IsFinished == false);
        }
    }
}