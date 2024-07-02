using Service.ViewModel.Dtos;

namespace Service.ViewModel.Stores.OrderFiltr.SearchFilter
{
    public class SearchOrderDecorator : FiltrDecorator
    {
        private string _searchText { get; }

        public SearchOrderDecorator(IFilter filter, string searchText) : base(filter)
        {
            _searchText = searchText;
        }

        public override IEnumerable<OrderDto> GetOrderDtos()
        {

            return base.GetOrderDtos().Where(o => !string.IsNullOrEmpty(o.ContactName)
            && o.ContactName.Contains(_searchText)
            || o.ContactPhoneNumber.Contains(_searchText)
            || o.Device.Contains(_searchText)
            || o.Model.Contains(_searchText)
            || o.OrderName.Contains(_searchText)).ToList();
        }
    }
}