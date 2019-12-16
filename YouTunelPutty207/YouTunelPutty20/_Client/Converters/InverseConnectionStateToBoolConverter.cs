using System;
using System.Globalization;
using System.Windows.Data;
using YouTunelPutty20._Client.Model;

namespace YouTunelPutty20._Client.Converters
{
    internal class InverseConnectionStateToBoolConverter : BaseConverter, IValueConverter 
    {
     
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ConnectionState))
                throw new InvalidOperationException("The target must be a boolean");            
            return (ConnectionState)value == ConnectionState.Disconnected;            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
