using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// <para>Expects an <see cref="object" />.</para>
    /// <para>Returns <see cref="Visibility.Visible" /> if the value is not <see langword="null"/>.</para>
    /// <para>Returns <see cref="Visibility.Hidden" /> if the value is <see langword="null"/> and "Hidden" was set as a parameter.</para>
    /// <para>Returns <see cref="Visibility.Collapsed" /> otherwise.</para>
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class ValueNullToInverseVisibilityConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new ValueNullToInverseVisibilityConverter());

        /// <inheritdoc />
        public virtual object Convert(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (value != null)
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        /// <inheritdoc />
        /// <exception cref="NotSupportedException">This operation is not supported.</exception>
        public virtual object ConvertBack(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            throw new NotSupportedException();
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