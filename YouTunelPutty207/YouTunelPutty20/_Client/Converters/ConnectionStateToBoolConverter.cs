using System;
using System.Globalization;
using System.Windows.Data;
using YouTunelPutty20._Client.Model;

namespace YouTunelPutty20._Client.Converters
{
    internal class ConnectionStateToBoolConverter : BaseConverter, IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = value is ConnectionState ? (ConnectionState) value : ConnectionState.Disconnected;
            return state != ConnectionState.Disconnected;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return value is bool && (bool)value;
            var boolValue =  value is bool && (bool)value;
            return boolValue == false ? ConnectionState.Disconnected : ConnectionState.Connected;
        }
    }
}
