using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Converter
{
   public class Converter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return (string)(parameter) == "1" ? (bool)value ? "Важно" : "Не важно" : (bool)value ? "Срочно" : "Не срочно";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
         return   (bool)value ? true : false;
        }
    }
}
