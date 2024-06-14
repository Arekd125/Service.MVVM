using Service.ViewModel.Commands.PanelControlCommand;
using Service.ViewModel.Stores;
using Service.ViewModel.Stores.Converstes;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels
{
    public class PanelControlViewModel : ViewModelBase
    {
        private readonly OrdersFilter _ordersFilter;

        public int BufforDateFilerSelectedIndex { get; set; }

        public ICommand OnToggleButton { get; }
        public ICommand OffToggleButton { get; }

        public IEnumerable<DateFilerEnum> DateFilerItemSource => Enum.GetValues<DateFilerEnum>();

        private DateFilerEnum _dateFilerSelectedIndex = DateFilerEnum.month;

        public int DateFilerSelectedIndex
        {
            get
            {
                return (int)_dateFilerSelectedIndex;
            }
            set
            {
                _dateFilerSelectedIndex = (DateFilerEnum)value;
                OnPropertyChanged(nameof(DateFilerSelectedIndex));
                _ordersFilter.SelectDateFilter(_dateFilerSelectedIndex);
            }
        }

        public PanelControlViewModel(OrdersFilter ordersFilter, OrderStore orderStore)
        {
            _ordersFilter = ordersFilter;
            OnToggleButton = new ToggleSwitchOnCommand(this, orderStore);
            OffToggleButton = new ToggleSwitchOffCommand(this);
        }
    }
}