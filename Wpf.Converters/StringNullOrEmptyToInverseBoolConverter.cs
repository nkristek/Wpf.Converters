using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="string"/>.
    /// Returns true if it is not null or empty.
    /// </summary>
    public class StringNullOrEmptyToInverseBoolConverter
        : MarkupExtension, IValueConverter
    {
        public static readonly IValueConverter Instance = new StringNullOrEmptyToInverseBoolConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !String.IsNullOrEmpty(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
