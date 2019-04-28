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
    // [ToDo] Не очень говорящие названия для конвертеров: Converter1 и Converter2. 
    // Что делают эти конвертеры. Сможет ли программист, их использующий, не заглядывая в код
    // сообразить как и где их использовать, что от них ожидать?
    public class Converter1 : IValueConverter
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



