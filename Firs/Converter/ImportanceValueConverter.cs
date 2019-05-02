using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Converter
{
    // [ToDo] Наименование класса не вполне соответствует его сущности.
    // Это конвертер и его имя должно оканчиваться на Converter.
    // Также не очень хорошо с точки зрения проектирования использовать параметры в качестве
    // селектора алгоритма, как здесь (для разделения срочности и важности).
    // Гораздо лучше сделать два конвертера. Это всегда способствует лучшей изоляции проблем,
    // большей понятности сценария использования конвертеров для других разработчиков. 
    // Рекомендуется: UrgencyTextConverter, ImportanceTextConverter.

        // Выполнил
    public class ImportanceValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Random rm=new Random();
           

            if ((bool)(value)) { return rm.Next(1,149); }
            else { return rm.Next(151, 259); }



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value >= 150) { return false; }
            else { return true; }

        }
    }
}
