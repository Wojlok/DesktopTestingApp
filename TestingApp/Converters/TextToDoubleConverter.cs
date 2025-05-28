using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace View.Converters
{
    class TextToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? input = (double?)value;
            if (input == null) return "";
            return input.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string input = ((string)value).Replace(".", ",");
                if (input == "") return null;
                return System.Convert.ToDouble(input);
            }
            catch
            {
                return null;
            }
        }
    }
}
