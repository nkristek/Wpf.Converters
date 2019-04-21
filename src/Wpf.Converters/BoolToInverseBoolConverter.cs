using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects a <see cref="bool" />.
    ///     Returns its opposite.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class BoolToInverseBoolConverter
#if NET35
        : IValueConverter
#else
        : MarkupExtension, IValueConverter
#endif
    {
        private static IValueConverter _instance;

        /// <summary>
        /// Static instance of this converter.
        /// </summary>
        public static IValueConverter Instance => _instance ?? (_instance = new BoolToInverseBoolConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return Binding.DoNothing;

            var boolValue = (bool) value;
            return !boolValue;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }

#if !NET35
        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
#endif
    }
}