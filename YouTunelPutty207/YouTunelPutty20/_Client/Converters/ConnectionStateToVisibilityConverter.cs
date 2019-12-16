using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using YouTunelPutty20._Client.Model;

namespace YouTunelPutty20._Client.Converters
{
    internal class ConnectionStateToVisibilityConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = value is ConnectionState ? (ConnectionState)value : ConnectionState.Disconnected;
            return state == ConnectionState.Connecting ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
