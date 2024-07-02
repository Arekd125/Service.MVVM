using Service.ViewModel.Service;
using System.Windows;

namespace Service.View.Dialogs
{
    public class DialogService : IDialogService
    {
        public static Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public static void RegisterDialog<TView, TViewModel>()
        {
            _mappings.Add(typeof(TViewModel), typeof(TView));
        }

        public void ShowDialog<ViewModel>(ViewModel viewModel)
        {
            var type = _mappings[typeof(ViewModel)];
            var VmType = typeof(ViewModel);

            var dialog = new DialogWindow();
            var Content = Activator.CreateInstance(type);
            if (VmType != null)
            {
                (Content as FrameworkElement).DataContext = viewModel;
            }

            dialog.Content = Content;

            dialog.ShowDialog();
        }
    }
}