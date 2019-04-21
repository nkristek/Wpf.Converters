using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects a <see cref="bool" />.
    ///     Returns <see cref="Visibility.Visible" /> if it is false.
    ///     Returns <see cref="Visibility.Hidden" /> if true and "Hidden" was set as the parameter.
    ///     Returns <see cref="Visibility.Collapsed" /> otherwise.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToInverseVisibilityConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new BoolToInverseVisibilityConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return Binding.DoNothing;

            var boolValue = (bool) value;
            if (!boolValue)
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility))
                return Binding.DoNothing;

            var visibilityValue = (Visibility) value;
            return visibilityValue != Visibility.Visible;
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