using System.Windows;
using System.Windows.Controls;

namespace Service.View.Views
{
    /// <summary>
    /// Interaction logic for OrdersListingView.xaml
    /// </summary>
    public partial class OrdersListingView : UserControl
    {
        public OrdersListingView()
        {
            InitializeComponent();
        }

        public void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            var row = (DataGridRow)sender;
            row.DetailsVisibility = row.DetailsVisibility == Visibility.Collapsed ?
               Visibility.Visible : Visibility.Collapsed;
        }
    }
}