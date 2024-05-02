using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class FlayoutVewModel : ViewModelBase
    {
        public FlayoutVewModel()
        { }

        private SolidColorBrush _backgroudColorFlyout;

        public SolidColorBrush BackgroudColorFlyout
        {
            get
            {
                return _backgroudColorFlyout;
            }
            set
            {
                _backgroudColorFlyout = value;
                OnPropertyChanged(nameof(BackgroudColorFlyout));
            }
        }

        private bool _openFlyout = false;

        public bool OpenFlyout
        {
            get
            {
                return _openFlyout;
            }
            set
            {
                _openFlyout = value;
                OnPropertyChanged(nameof(OpenFlyout));
            }
        }

        private string _messageFlyout;

        public string MessageFlyout
        {
            get
            {
                return _messageFlyout;
            }
            set
            {
                _messageFlyout = value;
                OnPropertyChanged(nameof(MessageFlyout));
            }
        }

        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public async Task ShowFlyout(string flyoutmessage, Color color = default(Color))
        {
            if (color == default(Color))
            {
                color = (Color)ColorConverter.ConvertFromString("#2196f3");
            }

            BackgroudColorFlyout = new SolidColorBrush(color);

            await semaphore.WaitAsync();
            try
            {
                OpenFlyout = true;
                MessageFlyout = flyoutmessage;

                await Task.Delay(3000);

                OpenFlyout = false;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}