using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace First.Service
{
    // [ToDo] Очевидно, в этом проекте не место ни конвертерам, ни классу RelayCommand.
    // RelayCommand относится к слою view model, и должна быть там, в то время, как 
    // конвертеры относятся исключительно к слою view
    class TypeListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
