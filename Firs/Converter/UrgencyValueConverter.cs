using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Converter
{
 
    public class UrgencyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Random rm = new Random();


            if (!(bool)(value)) { return rm.Next(1, 149); }
            else { return rm.Next(151, 259); }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value >= 150) { return true; }
            else { return false; }
        }
    }
}
