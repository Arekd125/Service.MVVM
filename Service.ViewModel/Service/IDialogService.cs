namespace Service.ViewModel.Service
{
    public interface IDialogService
    {
        public void ShowDialog<ViewModel>(ViewModel viewModel);
    }
}