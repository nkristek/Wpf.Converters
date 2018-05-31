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
    /// Expects a list of <see cref="bool"/>.
    /// Returns true if all of them are true.
    /// </summary>
    [ValueConversion(typeof(IEnumerable<bool>), typeof(bool))]
    public class AllBoolToVisibilityConverter
        : MarkupExtension, IMultiValueConverter
    {
        private static IMultiValueConverter _instance;

        public static IMultiValueConverter Instance => _instance ?? (_instance = new AllBoolToVisibilityConverter());

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.All(v => v is bool b && b))
                return Visibility.Visible;

            if ("Hidden".Equals(parameter as string, StringComparison.OrdinalIgnoreCase))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
