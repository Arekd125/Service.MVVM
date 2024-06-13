using Service.ViewModel.Stores;
using Service.ViewModel.Stores.Converstes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
   

    public class PanelControlViewModel : ViewModelBase
    {
        private readonly OrdersFilter _ordersFilter;  
        public IEnumerable<DateFilerEnum> DateFilerItemSource => Enum.GetValues<DateFilerEnum>();


        private DateFilerEnum _dateFilerSelectedIndex ;

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
        public PanelControlViewModel(OrdersFilter ordersFilter)
        {
            _ordersFilter = ordersFilter;
        }

        

    }
}