using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Controllers
{
    // [ToDo] Наименование класса не вполне соответствует его сущности.
    // Это конвертер и его имя должно оканчиваться на Converter.
    // Также не очень хорошо с точки зрения проектирования использовать параметры в качестве
    // селектора алгоритма, как здесь (для разделения срочности и важности).
    // Гораздо лучше сделать два конвертера. Это всегда способствует лучшей изоляции проблем,
    // большей понятности сценария использования конвертеров для других разработчиков. 
    // Рекомендуется: UrgencyTextConverter, ImportanceTextConverter.
    public class ConverterValue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)parameter == "1")
            {
                if ((bool)value) { return "Важно"; }
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
