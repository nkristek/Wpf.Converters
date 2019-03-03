using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects <see cref="object" />.
    ///     Returns true if <see cref="object.ToString" /> equals the given parameter.
    /// </summary>
    [ValueConversion(typeof(object), typeof(bool))]
    public class ObjectToStringEqualsParameterToBoolConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new ObjectToStringEqualsParameterToBoolConverter());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() == parameter as string;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
    }
}