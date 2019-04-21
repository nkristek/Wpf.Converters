using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects <see cref="object" />.
    ///     Returns <see cref="Visibility.Visible" /> if it is not null.
    ///     Returns <see cref="Visibility.Hidden" /> if it is null and "Hidden" was set as a parameter.
    ///     Returns <see cref="Visibility.Collapsed" /> otherwise.
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class ValueNullToInverseVisibilityConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new ValueNullToInverseVisibilityConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
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