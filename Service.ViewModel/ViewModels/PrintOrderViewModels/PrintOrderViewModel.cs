namespace Service.ViewModel.ViewModels.PrintOrderViewModels
{
    public class PrintOrderViewModel
    {
        public PrintViewModel PrintViewModel { get; }

        public PrintOrderViewModel(PrintViewModel printViewModel)
        {
            PrintViewModel = printViewModel;
        }
    }
}