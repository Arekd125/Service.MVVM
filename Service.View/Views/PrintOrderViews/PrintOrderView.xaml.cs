using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace Service.View.Views.PrintOrderViews
{
    /// <summary>
    /// Interaction logic for PrintOrderView.xaml
    /// </summary>
    public partial class PrintOrderView : MetroWindow
    {
        public PrintOrderView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = true;
                this.PrintButton.Visibility = System.Windows.Visibility.Hidden;
                this.CloseButton.Visibility = System.Windows.Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Zlecenie");
                }
            }
            finally
            {      
                this.IsEnabled = true;
                this.PrintButton.Visibility = System.Windows.Visibility.Visible;
                this.CloseButton.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}