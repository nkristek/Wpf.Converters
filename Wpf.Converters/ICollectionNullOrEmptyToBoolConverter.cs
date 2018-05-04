using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace nkristek.Wpf.Converters
{
    /// <summary>
    /// Expects <see cref="ICollection"/>.
    /// Returns true if it is null or empty.
    /// </summary>
    public class ICollectionNullOrEmptyToBoolConverter
        : MarkupExtension, IValueConverter
    {
        public static readonly IValueConverter Instance = new ICollectionNullOrEmptyToBoolConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is ICollection) || ((ICollection) value).Count == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
