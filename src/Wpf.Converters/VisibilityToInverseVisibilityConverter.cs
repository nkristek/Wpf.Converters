using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects <see cref="Visibility" />.
    ///     Returns the opposite, if parameter is set to hidden, it will return <see cref="Visibility.Hidden" /> if
    ///     encountering <see cref="Visibility.Visible" />
    /// </summary>
    [ValueConversion(typeof(Visibility), typeof(Visibility))]
    public class VisibilityToInverseVisibilityConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new VisibilityToInverseVisibilityConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility))
                return Binding.DoNothing;

            var visibilityValue = (Visibility) value;
            if (visibilityValue != Visibility.Visible)
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;
            return Visibility.Collapsed;
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