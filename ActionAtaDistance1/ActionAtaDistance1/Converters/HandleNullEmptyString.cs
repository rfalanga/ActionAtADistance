using System;
using System.Globalization;
using System.Windows.Data;

namespace ActionAtaDistance1.Converters
{
    class HandleNullEmptyString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }

            var tmp = value.ToString();

            if (string.IsNullOrEmpty(tmp))
            {
                return "";
            }

            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
