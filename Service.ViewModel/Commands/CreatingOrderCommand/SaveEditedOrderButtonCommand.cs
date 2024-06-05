using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class SaveEditedOrderButtonCommand : SaveOrderButtonCommand
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public SaveEditedOrderButtonCommand(CreatingOrderViewModel creatingOrderViewModel, ContactViewModel contactViewModel, DeviceViewModel deviceViewModel) : base(creatingOrderViewModel, contactViewModel, deviceViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.EditOrder();
        }
    }
}