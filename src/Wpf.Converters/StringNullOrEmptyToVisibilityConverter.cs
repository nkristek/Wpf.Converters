using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects <see cref="string" />.
    ///     Returns <see cref="Visibility.Visible" /> if it is null or empty.
    ///     Returns <see cref="Visibility.Hidden" /> if it is not null or empty "Hidden" was set as a parameter.
    ///     Returns <see cref="Visibility.Collapsed" /> otherwise.
    /// </summary>
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class StringNullOrEmptyToVisibilityConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new StringNullOrEmptyToVisibilityConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !(value is string))
                return Binding.DoNothing;

            var stringValue = (string) value;
            if (String.IsNullOrEmpty(stringValue))
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