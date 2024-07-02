using Service.ViewModel.Commands.StatusBarCommand;
using Service.ViewModel.ViewModels.PrintOrderViewModels;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels.StatusBarViewVModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICommand SaveInprintButton { get; }

        private Inprint _inprint;

        public Inprint Inpritn
        {
            get
            {
                return _inprint;
            }
            set
            {
                _inprint = value;
                OnPropertyChanged(nameof(Inpritn));
            }
        }

        public SettingsViewModel(Inprint inprint)
        {
            _inprint = inprint;
            SaveInprintButton = new SaveInprintButtonCommand(_inprint);
        }
    }
}