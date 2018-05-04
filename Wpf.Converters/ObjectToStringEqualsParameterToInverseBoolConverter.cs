using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="object"/>.
    /// Returns false if <see cref="object.ToString"/> equals the given parameter.
    /// </summary>
    public class ObjectToStringEqualsParameterToInverseBoolConverter
        : MarkupExtension, IValueConverter
    {
        public static readonly IValueConverter Instance = new ObjectToStringEqualsParameterToInverseBoolConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterAsString = parameter as string;
            return value?.ToString() != parameterAsString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
