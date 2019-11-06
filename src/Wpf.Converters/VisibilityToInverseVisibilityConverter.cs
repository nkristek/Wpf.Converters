using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// <para>Expects a <see cref="Visibility" />.</para>
    /// <para>Returns <see cref="Visibility.Visible" /> if the value is <see cref="Visibility.Collapsed" /> or <see cref="Visibility.Hidden" />.</para>
    /// <para>Returns <see cref="Visibility.Hidden" /> if the value is <see cref="Visibility.Visible" /> and "Hidden" was set as a parameter.</para>
    /// <para>Returns <see cref="Visibility.Collapsed" /> otherwise.</para>
    /// </summary>
    [ValueConversion(typeof(Visibility), typeof(Visibility))]
    public class VisibilityToInverseVisibilityConverter
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
        public static IValueConverter Instance => _instance ?? (_instance = new VisibilityToInverseVisibilityConverter());

        /// <inheritdoc />
        public virtual object Convert(object value, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (!(value is Visibility visibilityValue))
                return DependencyProperty.UnsetValue;

            if (visibilityValue != Visibility.Visible)
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        /// <inheritdoc />
        public virtual object ConvertBack(object value, Type targetType, object? parameter, CultureInfo? culture)
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