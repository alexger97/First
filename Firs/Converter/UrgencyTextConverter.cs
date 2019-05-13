using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Converter
{
    // [ToDo] См. ImportanceTextConverter
    public class UrgencyTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
                if ((bool)value) { return "Срочно"; }
                else { return "Не срочно"; };
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotSupportedException();



        }
    }
}
