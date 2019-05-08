using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace First.Converter
{
    // [ToDo][Выполнено] > Наименование класса не вполне соответствует его сущности.
    // > Это конвертер и его имя должно оканчиваться на Converter.
    // > Также не очень хорошо с точки зрения проектирования использовать параметры в качестве
    // > селектора алгоритма, как здесь (для разделения срочности и важности).
    // > Гораздо лучше сделать два конвертера. Это всегда способствует лучшей изоляции проблем,
    // > большей понятности сценария использования конвертеров для других разработчиков. 
    // > Рекомендуется: UrgencyTextConverter, ImportanceTextConverter.
    public class ImportanceValueConverter : IValueConverter
    {
        // [ToDo][Выполнено?] Не для каждого преобразования существует обратное преобразование.
        // В данном случае можно смело кидать NotSupportedException. Нельзя из 'true' получить цифру.
        // См. ImportanceTextConverter. Здесь принцип тот же.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            return new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value >= 150) { return false; }
            else { return true; }

        }
    }
}
