namespace Service.ViewModel.ViewModels.PrintOrderViewModels
{
    public class PrintOrderViewModel
    {
        public PrintOrderViewModel(PrintViewModel printViewModel)
        {
            PrintViewModel = printViewModel;
        }

        public PrintViewModel PrintViewModel { get; }
    }
}