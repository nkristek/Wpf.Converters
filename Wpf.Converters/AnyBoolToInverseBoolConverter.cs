using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace NKristek.Wpf.Converters
{
    /// <summary>
    ///     Expects a list of <see cref="bool" />.
    ///     Returns true if all of them are false.
    /// </summary>
    [ValueConversion(typeof(IEnumerable<bool>), typeof(bool))]
    public class AnyBoolToInverseBoolConverter
        : MarkupExtension, IMultiValueConverter
    {
        private static IMultiValueConverter _instance;

        public static IMultiValueConverter Instance => _instance ?? (_instance = new AnyBoolToInverseBoolConverter());

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return !values.Any(v => v is bool b && b);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }
    }
}