using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    /// <para>Expects a <see cref="bool" />.</para>
    /// <para>Returns <see langword="true" /> if any value is <see langword="false"/>.</para>
    /// <para>Returns <see langword="false" /> otherwise.</para>
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class BoolToInverseBoolConverter
#if NET35
        : IValueConverter
#else
        : MarkupExtension, IValueConverter
#endif
    {
        private static IValueConverter? _instance;

        /// <summary>
        /// Static instance of this converter.
        /// </summary>
        public static IValueConverter Instance => _instance ?? (_instance = new BoolToInverseBoolConverter());

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (!(value is bool boolValue))
                return DependencyProperty.UnsetValue;

            return !boolValue;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            return Convert(value, targetType, parameter, culture);
        }

#if !NET35
        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider? serviceProvider)
        {
            return Instance;
        }
#endif
    }
}