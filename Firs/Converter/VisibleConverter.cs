using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace First.Converter
{
    // [ToDo][Выполнено?] VisibleConverter - хорошее название? Когда мы его видим, мы понимаем что во что преобразуется?
    // Даже VisibilityConverter не очень хорошее название. Предлагается выбрать наиболее очевидное для
    // использующего кода название конвертера.
    public class ListBoxIsVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotSupportedException();
        }
    }
}
