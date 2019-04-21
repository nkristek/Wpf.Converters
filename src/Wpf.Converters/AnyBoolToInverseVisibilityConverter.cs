using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects a list of <see cref="bool" />.
    ///     Returns <see cref="Visibility.Visible" /> if there are no elements in the list which are true, otherwise
    ///     <see cref="Visibility.Collapsed" />. Set "Hidden" as the parameter to return <see cref="Visibility.Hidden" />.
    /// </summary>
    [ValueConversion(typeof(IEnumerable<bool>), typeof(Visibility))]
    public class AnyBoolToInverseVisibilityConverter
#if NET35
        : IMultiValueConverter
#else
        : MarkupExtension, IMultiValueConverter
#endif
    {
        private static IMultiValueConverter _instance;

        /// <summary>
        /// Static instance of this converter.
        /// </summary>
        public static IMultiValueConverter Instance => _instance ?? (_instance = new AnyBoolToInverseVisibilityConverter());

        /// <inheritdoc />
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Any(v => v is bool b && b))
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        /// <inheritdoc />
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
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