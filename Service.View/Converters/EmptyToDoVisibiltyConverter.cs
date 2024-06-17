using Service.ViewModel.Dtos;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Service.View.Converters
{
    public class EmptyToDoVisibiltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }

            IEnumerable<ToDoDto> toDo = value as IEnumerable<ToDoDto>;
            return toDo.Any() && toDo != null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}