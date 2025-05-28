using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    /// <summary>
    /// Converter string-double.
    /// </summary>
    class TextToDoubleConverter : IValueConverter
    {

        /// <summary>
        /// Double to string converter.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? input = (double?)value;
            if (input == null) return "";
            return input.ToString();
        }

        /// <summary>
        /// String to double converter.
        /// </summary>
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
