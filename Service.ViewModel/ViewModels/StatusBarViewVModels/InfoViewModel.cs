using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.StatusBarViewVModels
{
    public class InfoViewModel
    {
        public AboutInfo AboutInfo { get; }

        public InfoViewModel(AboutInfo aboutInfo)
        {
            AboutInfo = aboutInfo;
        }
    }
}