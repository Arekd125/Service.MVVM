using MediatR;
using Service.ViewModel.Service.Queries.GetNumberOpenedOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class StatusBarViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;
        private int _openedOrders;

        public int OpenedOrders
        {
            get
            {
                _openedOrders = GetNumberOpenedOrders();
                return _openedOrders;
            }
            set
            {
                _openedOrders = value;
                OnPropertyChanged(nameof(OpenedOrders));
            }
        }

        public StatusBarViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public int GetNumberOpenedOrders()
        {
            return _mediator.Send(new GetNumberOpenedOrdersQuery()).Result;
        }
    }
}