using System;
using System.Globalization;
using System.Windows.Data;

namespace RestaurantManagement.Converters
{
    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isAvailable)
            {
                return isAvailable ? "Avaible" : "Unavaible";
            }
            return "Unavaible";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                return status == "Avaible";
            }
            return false;
        }
    }
}