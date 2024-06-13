using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Stores;
using Service.ViewModel.Stores.OrderFiltr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class OrderStatusTabControlViewModel : ViewModelBase
    {
        private readonly OrdersFilter _ordersFilter;

        private int _filtrStatus;

        public int FiltrStatus
        {
            get
            {
                return _filtrStatus;
            }
            set
            {
                _filtrStatus = value;
                OnPropertyChanged(nameof(FiltrStatus));
                _ordersFilter.SelectFiltr(FiltrStatus);
            }
        }

        public OrdersListingViewModel ordersListingViewModel { get; }

        public OrderStatusTabControlViewModel(OrdersListingViewModel ordersListingViewModel, OrdersFilter ordersFilter, IMediator mediator)
        {
            this.ordersListingViewModel = ordersListingViewModel;
            _ordersFilter = ordersFilter;
        }
    }
}