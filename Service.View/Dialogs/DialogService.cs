using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Service.View.Dialogs
{
    public class DialogService : IDialogService
    {
        public static Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public static void RegisterDialog<TView, TViewModel>()
        {
            _mappings.Add(typeof(TViewModel), typeof(TView));
        }

        public void ShowDialog<ViewModel>()
        {
            var type = _mappings[typeof(ViewModel)];
            var VmType = typeof(ViewModel);

            var dialog = new DialogWindow();
            var Content = Activator.CreateInstance(type);
            if (VmType != null)
            {
                var vm = Activator.CreateInstance(VmType);

                (Content as FrameworkElement).DataContext = vm;
            }

            dialog.Content = Content;

            dialog.ShowDialog();
        }
    }
}