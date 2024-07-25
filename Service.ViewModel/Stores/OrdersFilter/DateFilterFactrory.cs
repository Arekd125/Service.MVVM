using MediatR;
using Service.ViewModel.Stores.Converstes;
using Service.ViewModel.Stores.OrderFiltr;
using Service.ViewModel.Stores.OrderFiltr.DateFilter;

namespace Service.ViewModel.Stores.OrdersFilter
{
    public class DateFilterFactrory
    {
        private readonly IMediator _mediator;

        public DateFilterFactrory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IFilter CreateFilter(DateFilerEnum dateFilerEnum)
        {
            switch (dateFilerEnum)
            {
                case DateFilerEnum.today:
                    return new TodayOrdersFiilter(_mediator);

                case DateFilerEnum.yesterday:
                    return new YesterdayOrdersFilter(_mediator);

                case DateFilerEnum.week:
                    return new LastWeekOrdersFilter(_mediator);

                case DateFilerEnum.month:
                    return new LastMonth(_mediator);

                case DateFilerEnum.from_the_beginning:
                    return new FromTheBeginingOrdersFilter(_mediator);
            }

            return new LastMonth(_mediator);
        }
    }
}