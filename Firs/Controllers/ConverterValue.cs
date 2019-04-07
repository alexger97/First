using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Controllers
{
   public class ConverterValue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if ((string)parameter=="1")
            { if ((bool) value) { return "Важно"; }
                else { return "Не важно"; };
                        }
            else
            {

                if ((bool)value) { return "Срочно"; }
                else { return "Не срочно"; };
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
