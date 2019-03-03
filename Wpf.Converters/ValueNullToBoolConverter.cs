using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects <see cref="object" />.
    ///     Returns true if it is null.
    /// </summary>
    [ValueConversion(typeof(object), typeof(bool))]
    public class ValueNullToBoolConverter
        : MarkupExtension, IValueConverter
    {
        private static IValueConverter _instance;

        public static IValueConverter Instance => _instance ?? (_instance = new ValueNullToBoolConverter());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null;
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