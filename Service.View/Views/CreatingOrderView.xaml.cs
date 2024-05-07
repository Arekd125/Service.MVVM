using System.Windows.Controls;
using System.Windows.Data;

namespace Service.View.Views
{
    /// <summary>
    /// Interaction logic for CreatingOrderView.xaml
    /// </summary>
    public partial class CreatingOrderView : UserControl
    {
        public CreatingOrderView()
        {
            InitializeComponent();
        }

        //private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    // Pobierz ComboBox
        //    ComboBox comboBox = sender as ComboBox;

        //    // Sprawdź, czy ComboBox ma powiązanie z właściwością zaktualizowaną na PropertyChanged
        //    if (comboBox != null && comboBox.SelectedValue != null)
        //    {
        //        // Pobierz powiązanie z ComboBox
        //        BindingExpression binding = comboBox.GetBindingExpression(ComboBox.TextProperty);

        //        // Jeśli powiązanie istnieje, wywołaj UpdateSource
        //        if (binding != null)
        //        {
        //            binding.UpdateSource();
        //        }
        //    }
        //}
    }
}