using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// <para>Expects a sequence of <see cref="bool" />.</para>
    /// <para>Returns <see cref="Visibility.Visible" /> if all values are <see langword="false"/>.</para>
    /// <para>Returns <see cref="Visibility.Collapsed" /> otherwise.</para>
    /// <para>Set "Hidden" as the parameter to return <see cref="Visibility.Hidden" /> instead of <see cref="Visibility.Collapsed"/>.</para>
    /// </summary>
    [ValueConversion(typeof(bool[]), typeof(Visibility))]
    public class AnyBoolToInverseVisibilityConverter
#if NET35
        : IMultiValueConverter
#else
        : MarkupExtension, IMultiValueConverter
#endif
    {
        private static IMultiValueConverter? _instance;

        /// <summary>
        /// Static instance of this converter.
        /// </summary>
        public static IMultiValueConverter Instance => _instance ?? (_instance = new AnyBoolToInverseVisibilityConverter());

        /// <inheritdoc />
        public virtual object Convert(object[] values, Type targetType, object? parameter, CultureInfo? culture)
        {
            if (values == null)
                return DependencyProperty.UnsetValue;

            if (!values.Any(v => v is bool b && b))
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        /// <inheritdoc />
        /// <exception cref="NotSupportedException">This operation is not supported.</exception>
        public virtual object[] ConvertBack(object value, Type[] targetTypes, object? parameter, CultureInfo? culture)
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