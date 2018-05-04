using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects a list of <see cref="bool"/>.
    /// Returns <see cref="Visibility.Visible"/> if there are no elements in the list which are true
    /// </summary>
    public class AnyBoolToInverseVisibilityConverter
        : MarkupExtension, IMultiValueConverter
    {
        public static readonly IMultiValueConverter Instance = new AnyBoolToInverseVisibilityConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Any(v => v is bool b && b))
                return Visibility.Visible;

            if (parameter is string parameterAsString && parameterAsString.ToLower().Equals("hidden"))
                return Visibility.Hidden;

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
