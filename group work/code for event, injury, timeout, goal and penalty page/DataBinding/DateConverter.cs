using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBinding
{
        public class DateConverter : IValueConverter
    {
        public object Convert(
        object value,
        Type targetType,
        object parameter,
        System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(string) &&
              value.GetType() == typeof(DateTime))
            {
                return ((DateTime)value).ToShortDateString();
            }
            else  // Unable to convert
            {
                return value;
            }
        }
        public object ConvertBack(
          object value,
          Type targetType,
          object parameter,
          System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
