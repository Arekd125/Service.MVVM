using Service.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.ViewModel.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        protected void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreatingOrderViewModel.DeviceStateNameItemsSource) ||
                e.PropertyName == nameof(CreatingOrderViewModel.DeviceStateSelectedItem) ||
                e.PropertyName == nameof(CreatingOrderViewModel.ModelStateSelectedItem) ||
                e.PropertyName == nameof(CreatingOrderViewModel.ModelNameComboBox) ||
                e.PropertyName == nameof(CreatingOrderViewModel.DeviceNameComboBox))
            {
                OnCanExecutedChanged();
            }
        }
    }
}