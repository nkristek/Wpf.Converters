using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="Visibility"/>.
    /// Returns the opposite, if parameter is set to hidden, it will return <see cref="Visibility.Hidden"/> if encountering <see cref="Visibility.Visible"/>
    /// </summary>
    public class VisibilityToInverseVisibilityConverter 
        : MarkupExtension, IValueConverter
    {
        public static readonly IValueConverter Instance = new VisibilityToInverseVisibilityConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var valueAsVisibility = (Visibility)value;
            if (valueAsVisibility != Visibility.Visible)
                return Visibility.Visible;

            if (parameter is string parameterAsString && parameterAsString.ToLower().Equals("hidden"))
                return Visibility.Hidden;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
