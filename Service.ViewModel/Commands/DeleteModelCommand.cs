using Service.ViewModel.Service;
using Service.ViewModel.ViewModels.CreatingOrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Commands
{
    public class DeleteModelCommand : CommandBase
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;

      

        public DeleteModelCommand(CreatingOrderViewModel creatingOrderViewModel)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _creatingOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private bool CanExecuteValidator()
        {
            return (!string.IsNullOrEmpty(_creatingOrderViewModel.ModelStateSelectedItem));
        }

        public override bool CanExecute(object? parameter)
        {
            return CanExecuteValidator() && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _creatingOrderViewModel.DeleteModel();



        }
    }
}