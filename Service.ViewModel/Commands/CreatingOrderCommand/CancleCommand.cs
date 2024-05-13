using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands.CreatingOrderCommand
{
    public class CancleCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

        public CancleCommand(CreatingOrderViewModel creatingOrderViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.Clear();
        }
    }
}