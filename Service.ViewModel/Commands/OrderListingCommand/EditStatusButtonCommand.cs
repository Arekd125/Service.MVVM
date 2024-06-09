using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.ViewModel.Service.Commands.EditOrderStatus;
using Service.ViewModel.Stores;
using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.OrderListingCommand
{
    public class EditStatusButtonCommand : CommandBase
    {
        private readonly OrdersListingViewModel _ordersListingViewModel;
    

        public EditStatusButtonCommand(OrdersListingViewModel ordersListingViewModel)
        {
            _ordersListingViewModel = ordersListingViewModel;
         
        }
        public override void Execute(object? parameter)
        {
            _ordersListingViewModel.EditStatusOrder();




        }
    }
}
