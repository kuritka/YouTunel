using System;
using System.Windows.Markup;

namespace YouTunelPutty20._Client.Converters
{
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }

}
