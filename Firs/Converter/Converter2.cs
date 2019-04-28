using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Converter
{

     // [ToDo] См. комментарий к Converter1. Также вызывают нарекание отступы в коде. 
     // Рекомендуется использовать для отступов 4 пробела.
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
